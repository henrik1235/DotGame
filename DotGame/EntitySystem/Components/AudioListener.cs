﻿namespace DotGame.EntitySystem.Components
{
    public class AudioListener : Component
    {
        public override void Update(GameTime gameTime)
        {
            /*var listener = Entity.Scene.Engine.AudioDevice.Listener;
            var position = listener.Position;
            listener.Position = Entity.Transform.Position;
            listener.Velocity = listener.Position - position;
            listener.At = Vector3.TransformNormal(Camera.Lookat, Entity.Transform.Matrix);
            var camera = Entity.GetComponent<Camera>();
            if (camera == null)
                listener.Up = Vector3.UnitY;
            else
                listener.Up = camera.Up;
                */
        }
    }
}
