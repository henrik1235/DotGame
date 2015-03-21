﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotGame.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using Config = OpenTK.Configuration;
using Utilities = OpenTK.Platform.Utilities;
using OpenTK.Platform;

namespace DotGame.OpenGL4.Windows
{
    public class GameControl : DotGame.Graphics.IGameWindow, IWindowContainer
    {
        private IGraphicsDevice graphicsDevice;
        private Control control;

        public int Width
        {
            get { return control.Width; }
            set { control.Width = value; }
        }

        public int Height
        {
            get { return control.Height; }
            set { control.Height = value; }
        }

        public bool IsFullScreen
        {
            get { return false; }
            set { throw new NotImplementedException(); }
        }

        public IWindowInfo WindowInfo { get; private set; }

        public GameControl(Control control)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            if (control.IsDisposed)
                throw new ArgumentException("control is disposed", "control");

            this.control = control;
        }

        public IGraphicsDevice CreateDevice()
        {
            if (graphicsDevice != null)
                return graphicsDevice;

            WindowInfo = Utilities.CreateWindowsWindowInfo(control.Handle);
            GraphicsContext context = new GraphicsContext(GraphicsMode.Default, WindowInfo);
            context.LoadAll();
            graphicsDevice = new GraphicsDevice(this, context);
            return graphicsDevice;
        }

        public bool VSync
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
