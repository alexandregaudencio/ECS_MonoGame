using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Components
{
    public class Physics2D : GameComponent
    {
        private Transform transform;
        private Vector2 velocity = Vector2.Zero;
        private Vector2 acceleration = Vector2.Zero;
        private float mass = 1;

        private bool gravityActive = false;
        private float gravity = 1;
        public float GetGravity => gravityActive ? gravity : 0;

        public Transform Transform { get => transform; set => transform = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Acceleration { get => acceleration; set => acceleration = value; }
        public float Mass { get => mass; set => mass = value; }

        public void SetGravity(float gravity)
        {
            this.gravity = gravity;
        }

        public Physics2D(Game game, Transform transform) : base(game)
        {
            this.transform = transform;
        }

        public void AddForce(Vector2 direction)
        {
            acceleration *= direction * (float)Game.TargetElapsedTime.TotalMilliseconds;
        }

        public void Impulse(Vector2 direction, float Intensity)
        {
            Acceleration += direction * Intensity;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


    }
}
