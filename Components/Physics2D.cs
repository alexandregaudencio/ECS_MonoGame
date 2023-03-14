using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components
{
    public class Physics2D
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

        public Physics2D(Transform transform)
        {
            this.transform = transform;
        }






    }
}
