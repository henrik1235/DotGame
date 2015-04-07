﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotGame.Graphics;
using DotGame.Utils;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using DotGame.OpenGL4.Windows;

namespace DotGame.OpenGL4
{
    public sealed class GraphicsDevice : IGraphicsDevice
    {
        public bool IsDisposed { get; private set; }

        public DeviceCreationFlags CreationFlags { get; private set; }

        private GraphicsCapabilities capabilities;
        public GraphicsCapabilities Capabilities
        {
            get { return capabilities; }
        }
        public IGraphicsFactory Factory { get; private set; }
        public IRenderContext RenderContext { get; private set; }

        public IGameWindow DefaultWindow { get; private set; }
        public bool VSync
        {
            get { return Context.SwapInterval > 1; }
            set
            {
                //AssertCurrent
                Context.SwapInterval = value ? 1 : 0;
            }
        }

        internal GraphicsContext Context { get; private set; }
        internal bool IsCurrent { get { return Context.IsCurrent; } }

        internal StateManager StateManager { get; private set; }

        private IWindowContainer container;
                
        private List<Fbo> fboPool = new List<Fbo>();

        //Hardware/ Driver Information
        internal int GLSLVersionMajor { get; private set; }
        internal int GLSLVersionMinor { get; private set; }
        internal int OpenGLVersionMajor { get; private set; }
        internal int OpenGLVersionMinor { get; private set; }
        internal bool HasAnisotropicFiltering { get; private set; }
        internal bool HasS3TextureCompression { get; private set; }
        internal int TextureUnits { get; private set; }
        internal bool SupportsDebugOutput { get; private set; }

        //Sampler Values
        internal int MaxAnisotropicFiltering { get; private set; }
        internal int MaxTextureLoDBias { get; private set; }

        private DebugProc onDebugMessage;

        internal static int MipLevels(int width, int height, int depth = 0)
        {
            var max = Math.Max(width, Math.Max(height, depth));
            return (int)Math.Ceiling(Math.Log(max, 2));
        }

        public GraphicsDevice(IGameWindow window, IWindowContainer container, GraphicsContext context, DeviceCreationFlags creationFlags)
        {
            if (window == null)
                throw new ArgumentNullException("window");
            if (container == null)
                throw new ArgumentNullException("container");
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.IsDisposed)
                throw new ArgumentException("context is disposed.", "context");

            this.DefaultWindow = window;
            this.container = container;
            this.Context = context;
            this.CreationFlags = creationFlags;
            
            Log.Debug("Got context: [ColorFormat: {0}, Depth: {1}, Stencil: {2}, FSAA Samples: {3}, AccumulatorFormat: {4}, Buffers: {5}, Stereo: {6}]",
                Context.GraphicsMode.ColorFormat,
                Context.GraphicsMode.Depth,
                Context.GraphicsMode.Stencil,
                Context.GraphicsMode.Samples,
                Context.GraphicsMode.AccumulatorFormat,
                Context.GraphicsMode.Buffers,
                Context.GraphicsMode.Stereo);

            Context.LoadAll();

            capabilities = new GraphicsCapabilities();

            CheckVersion();

            Factory = new GraphicsFactory(this);
            StateManager = new OpenGL4.StateManager(this);
            this.RenderContext = new RenderContext(this);

            Context.MakeCurrent(null);
        }
        ~GraphicsDevice()
        {
            Dispose(false);
        }

        public void MakeCurrent()
        {
            Context.MakeCurrent(container.WindowInfo);
        }
        public void DetachCurrent()
        {
            Context.MakeCurrent(null);
        }

        private void CheckVersion()
        {
            OpenGLVersionMajor = GL.GetInteger(GetPName.MajorVersion);
            OpenGLVersionMinor = GL.GetInteger(GetPName.MinorVersion);

            Log.Debug("Renderer: {0}", GL.GetString(StringName.Renderer));
            Log.Debug("OpenGL Version: {0}.{1}", OpenGLVersionMajor, OpenGLVersionMinor);

            //GLSL Version string auslesen
            string glslVersionString = GL.GetString(StringName.ShadingLanguageVersion);
            if(string.IsNullOrWhiteSpace(glslVersionString))
                throw new Exception("Could not determine supported GLSL version");

            string glslVersionStringMajor = glslVersionString.Substring(0, glslVersionString.IndexOf('.'));
            string glslVersionStringMinor = glslVersionString.Substring(glslVersionString.IndexOf('.') + 1, 1);

            int glslVersionMajor;
            int glslVersionMinor;
            if (!int.TryParse(glslVersionStringMajor, out glslVersionMajor) || !int.TryParse(glslVersionStringMinor, out glslVersionMinor))
                throw new Exception("Could not determine supported GLSL version");

            GLSLVersionMajor = glslVersionMajor;
            GLSLVersionMinor = glslVersionMinor;

            Log.Debug("GLSL Version: {0}.{1}", GLSLVersionMajor, GLSLVersionMinor);

            //Extensions überprüfen
            int extensionCount = GL.GetInteger(GetPName.NumExtensions);
            for (int i = 0; i < extensionCount; i++)
            {
                string extension = GL.GetString(StringNameIndexed.Extensions, i);
                if (extension == "GL_EXT_texture_compression_s3tc")
                {
                    HasS3TextureCompression = true;
                }

                else if (extension == "GL_EXT_texture_filter_anisotropic")
                {
                    HasAnisotropicFiltering = true;
                    MaxAnisotropicFiltering  = (int)GL.GetFloat((GetPName)OpenTK.Graphics.OpenGL.ExtTextureFilterAnisotropic.MaxTextureMaxAnisotropyExt);
                }

                else if (extension == "GL_ARB_debug_output")
                {
                    SupportsDebugOutput = true;

                    if (CreationFlags.HasFlag(DeviceCreationFlags.Debug))
                    {
                        onDebugMessage = new DebugProc(OnDebugMessage);
                        GL.Enable(EnableCap.DebugOutput);
                        GL.DebugMessageCallback(onDebugMessage, IntPtr.Zero);

                        GL.DebugMessageControl(DebugSourceControl.DontCare, DebugTypeControl.DontCare, DebugSeverityControl.DontCare, 0, new int[0], true);
                    }
                }
                else if (extension == "GL_ARB_get_program_binary")
                {
                    capabilities.SupportsBinaryShaders = true;
                }
            }
            TextureUnits = GL.GetInteger(GetPName.MaxCombinedTextureImageUnits);
            MaxTextureLoDBias = GL.GetInteger(GetPName.MaxTextureLodBias);

            OpenGL4.GraphicsDevice.CheckGLError();
        }

        private void OnDebugMessage(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr user)
        {
            string sourceString = source.ToString();
            if (sourceString.StartsWith("DebugSource"))
                sourceString = sourceString.Remove(0, "DebugSource".Length);

            string typeString = type.ToString();
            if (typeString.StartsWith("DebugType"))
                typeString = typeString.Remove(0, "DebugType".Length);

            string severityString = severity.ToString();
            if (severityString.StartsWith("DebugSeverity"))
                severityString = severityString.Remove(0, "DebugSeverity".Length);

            Log.Debug("(OpenGL) ({0}) ({1}) ({2}) {3}", severityString, sourceString, typeString, Marshal.PtrToStringAnsi(message, length));
            Log.FlushBuffer();
        }

        public T Cast<T>(IGraphicsObject obj, string parameterName) where T : class, IGraphicsObject
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
            if (obj.IsDisposed)
                throw new ObjectDisposedException(parameterName);
            T ret = obj as T;
            if (ret == null)
                throw new ArgumentException("GraphicsObject is not part of this api.", parameterName);
            if (obj.GraphicsDevice != this)
                throw new ArgumentException("GraphicsObject is not part of this graphics device.", parameterName);
            return ret;
        }

        public int GetSizeOf(TextureFormat format)
        {
            throw new NotImplementedException();
        }

        public int GetSizeOf(VertexElementType format)
        {
            switch (format)
            {
                case VertexElementType.Single:
                    return 4;
                case VertexElementType.Vector2:
                    return 8;
                case VertexElementType.Vector3:
                    return 12;
                case VertexElementType.Vector4:
                    return 16;
                default:
                    throw new NotSupportedException("Format is not supported.");
            }
        }

        public int GetComponentsOf(VertexElementType format)
        {
            switch (format)
            {
                case VertexElementType.Single:
                    return 1;
                case VertexElementType.Vector2:
                    return 2;
                case VertexElementType.Vector3:
                    return 3;
                case VertexElementType.Vector4:
                    return 4;
                default:
                    throw new NotSupportedException("Format is not supported.");
            }
        }

        public int GetSizeOf(IndexFormat format)
        {
            switch (format)
            {
                case IndexFormat.Int32:
                case IndexFormat.UInt32:
                    return 4;
                case IndexFormat.Short16:
                case IndexFormat.UShort16:
                    return 2;
                default:
                    throw new NotSupportedException("Format is not supported.");
            }
        }

        public int GetSizeOf(VertexDescription description)
        {
            int size = 0;
            VertexElement[] elements = description.GetElements();
            for (int i = 0; i < elements.Length; i++)
                size += GetSizeOf(elements[i].Type);

            return size;
        }

        public void SwapBuffers()
        {
            // TODO (Joex3): Evtl. woanders hinschieben.
            ((GraphicsFactory)Factory).DisposeUnused();

            Context.SwapBuffers();
        }

        //RenderTarget
        internal Fbo GetFBO(int depth, params int[] color)
        {
            if(depth == -1 && (color == null || color.Length == 0))
                return null;

            for (int i = 0; i < fboPool.Count; i++)
            {
                if (fboPool[i].DepthAttachmentID == depth && (fboPool[i].ColorAttachmentIDs == color || fboPool[i].ColorAttachmentIDs.Equals(color) || fboPool[i].ColorAttachmentIDs.SequenceEqual(color) || ((color == null || color.Length == 0) && (fboPool[i].ColorAttachmentIDs == null || fboPool[i].ColorAttachmentIDs.Length == 0))))
                {
                    return fboPool[i];
                }
            }

            GraphicsFactory factory = Cast<GraphicsFactory>(Factory, "factory");

            Fbo fbo = factory.CreateFbo(depth, color);
            fboPool.Add(fbo);
            return fbo;
        }

        internal Fbo GetFBO(int depth, int color)
        {
            return GetFBO(depth, new int[] { color });
        }

        internal Fbo GetFBO(int depth)
        {
            return GetFBO(depth, new int[] { });
        }

        internal static void CheckGLError()
        {
            var error = GL.GetError();
            if (error != ErrorCode.NoError)
            {
                throw new InvalidOperationException("OpenGL threw an error: " + error.ToString());
            }
        }

        public void Dispose()
        {
            Log.Info("GraphicsDevice.Dispose() called!");
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (Factory != null)
                Factory.Dispose();
            if (Context != null)
                Context.Dispose();
            IsDisposed = true; 
            GC.SuppressFinalize(this);
        }
    }
}
