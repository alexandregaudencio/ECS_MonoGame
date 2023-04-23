using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components.Cam
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
                Camera.Transform.Translate(Vector3.Left);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Camera.Transform.Translate(Vector3.Right);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Camera.Transform.Translate(Vector3.Forward);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Camera.Transform.Translate(Vector3.Backward);
            }

        }

    }
}
