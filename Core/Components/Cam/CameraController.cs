using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
                Camera.Transform.Translate(Vector3.Left*10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Right);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Up);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Down);
            }


        }

    }
}
