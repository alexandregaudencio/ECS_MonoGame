using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ECS.Core.Managers;

namespace ECS.Core.MovementController
{
    class CarMovementControl : MovementControl
    {

         public CarMovementControl(Game game, Transform transform) : base(game, transform)
        {
            Speed = 0.3f;
        }




        public override void UpdateMovement(Transform transform)
        {

            if (!Active) return;
            LastPosition = transform.Translation;

            Vector3 direction = Vector3.Zero;
            if (Keyboard.GetState().IsKeyDown(Right)) transform.RotateY(-Speed/3);
            if (Keyboard.GetState().IsKeyDown(Left)) transform.RotateY(Speed/3);
            if (Keyboard.GetState().IsKeyDown(Down)) transform.Translate(transform.World.Left * Speed);
            if (Keyboard.GetState().IsKeyDown(UP)) transform.Translate(transform.World.Right * Speed);


        }
    }

}
