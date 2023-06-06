using ECS.Core.Components;
using ECS.Core.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECS.Core.MovementController
{
    public class DirectionalMovementControl : GameComponent, IMovementControl
    {
        private Transform transform;
        public float Speed { get; set; } 
        public bool Active { get; private set; } 
        public Keys Left { get; set; } 
        public Keys Right { get; set; } 
        public Keys UP { get; set; } 
        public Keys Down { get; set; } 
        public bool IncluseRotation { get; set; } 
        public void SetActive(bool active) { Active = active;}
        public Vector3 LastPosition { get; set; }   


        public DirectionalMovementControl(Game game, Transform transform) : base(game)
        {
            Speed = 5;
            Active = false;
            Left = Keys.A;
            Right= Keys.D;
            UP = Keys.W;
            Down = Keys.S;
            IncluseRotation = false;

            this.transform = transform;
        }

        public override void Initialize()
        {
            LastPosition = transform.Translation;

            base.Initialize();
        }
        public void RestorePosition(Transform transform)
        {
            transform.SetTranslation(LastPosition);

        }

        public void UpdateMovement(Transform transform)
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
