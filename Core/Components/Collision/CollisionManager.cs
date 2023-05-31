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
        private List<Collider> colliders;

        public CollisionManager(Game game) : base(game)
        {
            colliders = new List<Collider>();
        }

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }


        public void processCollisions()
        {

            for (int i = 0;i < colliders.Count; i++)
            {
                for (int j = i; j < colliders.Count; j++)
                {
                    if (j == colliders.Count - 1) continue;
                    if (colliders[j].BoundingBox.Intersects(colliders[j+1].BoundingBox)) {
                        colliders[j].isColliding = true;
                        colliders[j+1].isColliding = true;
                        Debug.WriteLine("Collidiu");

                    } 

                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            processCollisions();
            base.Update(gameTime);
        }
    }
}
