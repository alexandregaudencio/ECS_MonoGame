using ECS.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECS.Core.MovementController
{
    public class DirectionalMovementControl : GameComponent, IMovementControl
    {
        private Transform transform;
        public float Speed { get; set; } = 0.001f;
        public bool Active { get; set; } = false;
        public Keys Left { get; set; } = Keys.A;
        public Keys Right { get; set; } = Keys.D;
        public Keys UP { get; set; } = Keys.W;
        public Keys Down { get; set; } = Keys.S;
        public bool IncluseRotation { get; set; } = true;

        public DirectionalMovementControl(Game game, Transform transform) : base(game)
        {
            this.transform = transform;
        }

        public void UpdateTransform(Transform transform) => this.transform = transform;

        public override void Update(GameTime gameTime)
        {
            if (!Active) return;
            Vector3 direction = Vector3.Zero;
            if (Keyboard.GetState().IsKeyDown(Right)) direction += Vector3.UnitX;
            if (Keyboard.GetState().IsKeyDown(Left)) direction -= Vector3.UnitX;
            if (Keyboard.GetState().IsKeyDown(Down)) direction += Vector3.UnitZ;
            if (Keyboard.GetState().IsKeyDown(UP)) direction -= Vector3.UnitZ;

            if (direction == Vector3.Zero) return;
            direction.Normalize();
            transform.Translate(direction * Speed * gameTime.ElapsedGameTime.Milliseconds);

            //if (!IncluseRotation) return;
            //Vector3 targetRotation = Vector3.Lerp(transform.Rotation, direction,1);
            //transform.SetRotation(targetRotation);

            base.Update(gameTime);
        }



    }
}
