using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ECS.Core.Components.Cam
{
    internal class CameraController : GameComponent
    {
        public Camera Camera { get; set; }
        private Transform target;

        public CameraController(Game game, Camera camera) : base(game)
        {
            Camera = camera;
            target = new Transform(game);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateCameraMovement(gameTime);
            Camera.CameraTarget = target.Translation;
        }


        public void SetCameraTarget(Transform transform)
        {
            target = transform;
        }



        private void UpdateCameraMovement(GameTime gameTime)
        {
            //LEFT
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                Camera.Transform.Translate(Camera.Transform.World.Backward*gameTime.ElapsedGameTime.Milliseconds*0.1f);
            }

            //RIGHT
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
            {
                Camera.Transform.Translate(Camera.Transform.World.Forward * gameTime.ElapsedGameTime.Milliseconds * 0.1f);

            }
            //FORWARD
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            {
                Camera.Transform.Translate(Camera.Transform.World.Left * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }

            //BACKWARD
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            {
                Camera.Transform.Translate(Camera.Transform.World.Right * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }

            //DOWN
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                Camera.Transform.Translate(Camera.Transform.World.Down * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }
            //UP
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad9))
            {
                Camera.Transform.Translate(Camera.Transform.World.Up * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }
        }
    }
}
