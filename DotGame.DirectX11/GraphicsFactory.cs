﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DotGame.Graphics;

namespace DotGame.DirectX11
{
    public class GraphicsFactory : GraphicsObject, IGraphicsFactory
    {
        internal GraphicsFactory(GraphicsDevice graphicsDevice)
            : base(graphicsDevice, new StackTrace(1))
        {
            if (graphicsDevice == null)
                throw new ArgumentNullException("graphicsDevice");
            if (graphicsDevice.IsDisposed)
                throw new ArgumentException("graphicsDevice is disposed.", "graphicsDevice");
            this.graphicsDevice = graphicsDevice;
        }

        public ITexture2D CreateTexture2D(int width, int height, TextureFormat format)
        {
            return new Texture2D(graphicsDevice, width, height, 0, format, 1, false);
        }

        public ITexture3D CreateTexture3D(int width, int height, int length, TextureFormat format)
        {
            throw new NotImplementedException();
        }

        public ITexture2DArray CreateTexture2DArray(int width, int height, TextureFormat format, int arraySize)
        {
            return new Texture2D(graphicsDevice, width, height, 0, format, arraySize, false);
        }

        public ITexture3DArray CreateTexture3DArray(int width, int height, int length, TextureFormat format, int arraySize)
        {
            throw new NotImplementedException();
        }

        public IRenderTarget2D CreateRenderTarget2D(int width, int height, TextureFormat format)
        {
            return new Texture2D(graphicsDevice, width, height, 0, format, 1, true);
        }

        public IRenderTarget3D CreateRenderTarget3D(int width, int height, int length, TextureFormat format)
        {
            throw new NotImplementedException();
        }

        public IRenderTarget2DArray CreateRenderTarget2DArray(int width, int height, TextureFormat format, int arraySize)
        {
            return new Texture2D(graphicsDevice, width, height, 0, format, arraySize, true);
        }

        public IRenderTarget3DArray CreateRenderTarget3DArray(int width, int height, int length, TextureFormat format, int arraySize)
        {
            throw new NotImplementedException();
        }

        public IVertexBuffer CreateVertexBuffer<T>(T[] data, VertexDescription description) where T : struct, IVertexType
        {
            VertexBuffer buffer = new VertexBuffer(graphicsDevice, description);
            buffer.SetData(data);
            return buffer;
        }

        public IIndexBuffer CreateIndexBuffer<T>(T[] data) where T : struct
        {
            IndexBuffer buffer = new IndexBuffer(graphicsDevice);
            buffer.SetData(data);
            return buffer;
        }

        public IConstantBuffer CreateConstantBuffer(int size)
        {
            return new ConstantBuffer(graphicsDevice, size);
        }

        public IShader CompileShader(string file)
        {
            throw new NotImplementedException();
        }


        protected override void Dispose(bool isDisposing)
        {
            // TODO (henrik1235) Alle erzeugten Objekte disposen
        }
    }
}