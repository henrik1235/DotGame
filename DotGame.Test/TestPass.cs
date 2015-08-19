﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotGame.Utils;
using DotGame.Rendering;
using DotGame.Graphics;
using DotGame.EntitySystem.Components;

namespace DotGame.Test
{
    public class TestPass : Pass
    {
        public Scene Scene { get; private set; }

        private List<Renderer> items = new List<Renderer>();

        public TestPass(Engine engine, Scene scene)
            : base(engine, new TestShader(engine))
        {
            if (scene == null)
                throw new ArgumentNullException("scene");

            this.Scene = scene;
        }

        public override void Render(GameTime gameTime)
        {
            Engine.GraphicsDevice.RenderContext.Clear(ClearOptions.ColorDepth, Color.LightSkyBlue, 1, 0);

            items.Clear();
            //Scene.PrepareDraw(gameTime, items);

            for (int i = 0; i < items.Count; i++)
                items[i].Draw(gameTime, this, Engine.GraphicsDevice.RenderContext);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (Shader != null)
                Shader.Dispose();
        }
    }
}
