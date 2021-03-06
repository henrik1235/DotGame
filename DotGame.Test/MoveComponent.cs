﻿using DotGame.EntitySystem;
using System;
using System.Numerics;

namespace DotGame.Test
{
    public class MoveComponent : Component
    {
        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.TotalTime.TotalMilliseconds / 1000f;
            Entity.Transform.LocalPosition = new Vector3(Entity.Transform.LocalPosition.X, Entity.Transform.LocalPosition.Y, (float)Math.Sin(t) * 20 + (float)Math.Sin(t) * 10);
        }
    }
}
