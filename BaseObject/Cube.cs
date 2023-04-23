using ECS.Components;
using ECS.Components.Cam;
using ECS.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.BaseObject
{
    public class Cube : EntityBase
    {
        private readonly Shape shape;
        public Cube(Game game, ICamPerspective perspective) : base(game)
        {
            shape = new Cuboid(game, perspective);
            shape.Transform = this.Transform;
            Transform.Translate(Vector3.Up);

        }

        public override void Initialize()
        {
            Game.Components.Add(shape);
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Transform.Translate(Vector3.Left);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Transform.Translate(Vector3.Right);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Transform.Translate(Vector3.Forward);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Transform.Translate(Vector3.Backward);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Transform.RotateY(0.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Transform.RotateY(-0.1f);
            }
            base.Update(gameTime);
        }


    }

}
