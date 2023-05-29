using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ECS.Core.Components.Cam
{
    internal class CameraController : GameComponent
    {
        public Camera Camera { get; set; }

        public CameraController(Game game, Camera camera) : base(game)
        {
            Camera = camera;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Forward);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Backward);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Left);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Right);
            }


        }

    }
}
