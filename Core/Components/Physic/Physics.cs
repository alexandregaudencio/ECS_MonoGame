//using ECS.Core.Components.Collision;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS.Core.Components.Physic
//{
//    public class Physics : GameComponent, IPhysics
//    {

//        public Transform transform;
//        private ICollider collider;
//        private float dt;

//        public bool Active { get; set; } = false;
//        public Transform Trransform => transform;
//        public Vector3 Velocity { get; set; } = Vector3.Zero;
//        public Vector3 Acceleration { get;private set; } = Vector3.Zero;


//        public Physics(Game game, Transform transform, ICollider collider) : base(game)
//        {
//            this.transform = transform;
//            this.collider = collider;
//        }

//        public void ApplyForce(Vector3 force)
//        {
//            Acceleration += (force * dt)/*/ Mass*/;

//        }

//        public void ApplyImpulse(Vector3 force, float intensity)
//        {
//            Acceleration += force*dt* intensity;
//        }

//        public void UpdatePhysic(GameTime gameTime)
//        {
//            Velocity += Acceleration * dt;

//            //MRU();
//        }



//        //public void MRU()
//        //{
//        //    transform.Translate(Velocity * dt + (Acceleration * dt * dt) / 2);
//        //}

//        public override void Update(GameTime gameTime)
//        {
//            //Debug.WriteLine("physics enalbed: "+Active);
//            Debug.WriteLine("aaceleration: " + Velocity);

//            if (!Active) return;

//            dt = gameTime.ElapsedGameTime.Milliseconds;
//            UpdatePhysic(gameTime);


//            base.Update(gameTime);
//        }
//    }
//}
