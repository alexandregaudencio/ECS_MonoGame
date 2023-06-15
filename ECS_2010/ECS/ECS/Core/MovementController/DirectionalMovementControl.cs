using ECS.Core.Components;
using ECS.Core.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECS.Core.MovementController
{
    public class DirectionalMovementControl : MovementControl
    {

        public DirectionalMovementControl(Game game, Transform transform) : base(game, transform)
        {

        }


        public override void UpdateMovement(Transform transform)
        {

            if (!Active) return;
            LastPosition = transform.Translation;

            Vector3 direction = Vector3.Zero;
            if (Keyboard.GetState().IsKeyDown(Right)) direction += Vector3.UnitX;
            if (Keyboard.GetState().IsKeyDown(Left)) direction -= Vector3.UnitX;
            if (Keyboard.GetState().IsKeyDown(Down)) direction += Vector3.UnitZ;
            if (Keyboard.GetState().IsKeyDown(UP)) direction -= Vector3.UnitZ;

            if (direction == Vector3.Zero) return;
            direction.Normalize();
            transform.Translate(direction * Speed * Time.Instance.ElapsedTime);

            //if (!IncluseRotation) return;
            //Vector3 targetRotation = Vector3.Lerp(transform.Rotation, direction,1);
            //transform.SetRotation(targetRotation);

        }


    }
}
