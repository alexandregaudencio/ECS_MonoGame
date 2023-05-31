using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ECS.Core.Components.Collision
{
    public class CollisionManager : GameComponent
    {
        private static CollisionManager instance;
        public static CollisionManager Instance => instance;

        private readonly List<ICollider> colliders;

        public CollisionManager(Game game) : base(game)
        {
            instance  = this;
            colliders = new List<ICollider>();
        }

        //public override void Initialize()
        //{
        //    Game.Components.Add(this);
        //    base.Initialize();
        //}
        public override void Update(GameTime gameTime)
        {
            ProcessCollisions();
            base.Update(gameTime);
        }


        public void AddColliders(params ICollider[] colliders)
        {
            if (colliders == null) return;
            Debug.WriteLine(colliders.Length);
            foreach(ICollider collider in colliders)
                this.colliders.Add(collider);
        }


        public void ProcessCollisions()
        {

            //from the first one to previous last.
            for (int i = 0;i < colliders.Count-1; i++)
            {
                //from the next to fist to last 
                for (int j = i+1; j < colliders.Count; j++)
                
                {
                    //if (j == colliders.Count - 1) continue;
                    // i interset j

                    if (!colliders[i].IsColliding && !colliders[i].Boundary.Intersects(colliders[j].Boundary))
                    {
                        continue;
                    }

                    //if (!colliders[i].IsColliding && colliders[i].BoundingBox.Intersects(colliders[j].BoundingBox))
                    //{
                    //    colliders[i].OnCollisionEnter(colliders[j]);
                    //    colliders[j].OnCollisionEnter(colliders[i]);
                    //    continue;
                    //}
                    if (/*colliders[i].IsColliding &&*/ colliders[i].Boundary.Intersects(colliders[j].Boundary))
                    {

                        colliders[i].OnCollisionStay(colliders[j]);
                        colliders[j].OnCollisionStay(colliders[i]);
                        continue;
                    }
                    //if (colliders[i].IsColliding && !colliders[i].BoundingBox.Intersects(colliders[j].BoundingBox))
                    //{
                    //    colliders[i].OnCollisionExit(colliders[j]);
                    //    colliders[j].OnCollisionExit(colliders[i]);
                    //    continue;
                    //}


                }
            }
        }




    }
}
