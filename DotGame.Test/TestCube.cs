﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotGame.Geometry;
using DotGame.Assets;
using DotGame.Graphics;

namespace DotGame
{
    public class TestCube : Entity
    {
       private Material material;
       private Mesh mesh;
       private Matrix matrix;

        public TestCube(Engine engine)
            : base(engine, "TestCube")
        {
            material = new Material(engine, "TestMaterial");
            material.Texture = new Texture(engine, "TestTexture", engine.GraphicsDevice.Factory.LoadTexture2D("GeneticaMortarlessBlocks.jpg", true));

            mesh = Mesh.Create(Engine, "cube", new VertexPositionTexture[] 
                {
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,  1.0f, -1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, -1.0f, -1.0f),   new Vector2(1.0f, 1.0f)),
                
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,  1.0f,  1.0f),   new Vector2(1.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, -1.0f,  1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                
                    new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, 1.0f,  1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, 1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, 1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, 1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, 1.0f, -1.0f),   new Vector2(1.0f, 1.0f)),
                
                    new VertexPositionTexture(new Vector3(-1.0f,-1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,-1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,-1.0f,  1.0f),   new Vector2(1.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,-1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,-1.0f, -1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,-1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f,  1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,  1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f, -1.0f, -1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,  1.0f,  1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3(-1.0f,  1.0f, -1.0f),   new Vector2(1.0f, 1.0f)),
                
                    new VertexPositionTexture(new Vector3( 1.0f, -1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, -1.0f,  1.0f),   new Vector2(1.0f, 1.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f, -1.0f, -1.0f),   new Vector2(1.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f, -1.0f),   new Vector2(0.0f, 0.0f)),
                    new VertexPositionTexture(new Vector3( 1.0f,  1.0f,  1.0f),   new Vector2(0.0f, 1.0f)),
                });
        }

        protected override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.TotalTime.TotalSeconds;
            matrix = Matrix.CreateRotationX(time)
                * Matrix.CreateRotationY(time * 2)
                * Matrix.CreateRotationZ(time * .7f);
        }

        public override void Draw(GameTime gameTime, Rendering.Pass pass, IRenderContext context)
        {
            material.Apply(pass, context, matrix);
            mesh.Draw(context);
        }

        protected override void Dispose(bool isDisposing)
        {
            mesh.Dispose();
            material.Texture.Dispose();
            material.Dispose();
        }
    }
}
