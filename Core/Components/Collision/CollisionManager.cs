using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Components.Collision
{
    public class CollisionManager : GameComponent
    {
        private List<ICollider> colliders;

        public CollisionManager(Game game) : base(game)
        {
            colliders = new List<ICollider>();
        }

        public void AddColliders(params ICollider[] colliders)
        {
            if (colliders == null) return;
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

                    if (!colliders[i].IsColliding && !colliders[i].BoundingBox.Intersects(colliders[j].BoundingBox))
                    {
                        continue;
                    }

                    //if (!colliders[i].IsColliding && colliders[i].BoundingBox.Intersects(colliders[j].BoundingBox))
                    //{
                    //    colliders[i].OnCollisionEnter(colliders[j]);
                    //    colliders[j].OnCollisionEnter(colliders[i]);
                    //    continue;
                    //}
                    if (/*colliders[i].IsColliding &&*/ colliders[i].BoundingBox.Intersects(colliders[j].BoundingBox))
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


        public override void Update(GameTime gameTime)
        {
            ProcessCollisions();
            base.Update(gameTime);
        }
    }
}
