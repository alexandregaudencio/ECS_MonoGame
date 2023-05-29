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


        public void SetCameraTarget(Entity entity)
        {
            target = entity.Transform;
        }



        private void UpdateCameraMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Backward*gameTime.ElapsedGameTime.Milliseconds*0.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Forward * gameTime.ElapsedGameTime.Milliseconds * 0.1f);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Left * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Camera.Transform.Translate(Camera.Transform.Matrix.Right * gameTime.ElapsedGameTime.Milliseconds * 0.1f);
            }

        }
    }
}
