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

        public List<ICollider> Colliders { get; private set; } = new List<ICollider>();

        public CollisionManager(Game game) : base(game)
        {
            instance = this;
        }

        public override void Update(GameTime gameTime)
        {
             ProcessCollisions();
            base.Update(gameTime);
        }

        public void AddColliders(params ICollider[] colliders)
        {
            if (colliders == null) return;
            
            foreach (ICollider collider in colliders)
            {
                if (Colliders.Contains(collider)) continue;
                Colliders.Add(collider);
            }
        }
        public void RemoveColliders(params ICollider[] colliders)
        {
            if (colliders == null) return;
            
            foreach (ICollider collider in colliders)
            {
                if (!Colliders.Contains(collider)) continue;
                Colliders.Remove(collider);
            }

        }

        public void ProcessCollisions()
        {
            if (Colliders.Count <= 1) return;

            //from the first one to previous last(penultimate)
            for (int i = 0; i < Colliders.Count - 1; i++)
            {
                //from the next to fist to last 
                for (int j = i + 1; j < Colliders.Count; j++)
                {

                    //intesects and...
                    if (Colliders[i].Boundary.Intersects(Colliders[j].Boundary))
                    {
                        //was not in contact
                        if (!Colliders[i].IsContacting(Colliders[j]))
                        {
                            Colliders[i].Enter(Colliders[j]);
                            Colliders[j].Enter(Colliders[i]);
                            continue;
                        }
                        //was  in contact
                        if (Colliders[i].IsContacting(Colliders[j]))
                        {
                            Colliders[i].Stay(Colliders[j]);
                            Colliders[j].Stay(Colliders[i]);
                            continue;
                        }
                    }
                    //not intersect...
                    else
                    {
                        //and is contacting
                        if (Colliders[i].IsContacting(Colliders[j]))
                        {
                            Colliders[i].Exit(Colliders[j]);
                            Colliders[j].Exit(Colliders[i]);
                            continue;
                        }
                    }




                }
            }
        }




    }
}
