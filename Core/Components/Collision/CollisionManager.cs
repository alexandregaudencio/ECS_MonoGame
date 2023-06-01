using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECS.Core.Components.Collision
{
    public class CollisionManager : GameComponent
    {
        private static CollisionManager instance;
        public static CollisionManager Instance => instance;

        private readonly List<ICollider> colliders;

        public CollisionManager(Game game) : base(game)
        {
            instance = this;
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
            foreach (ICollider collider in colliders)
                this.colliders.Add(collider);
        }


        public void ProcessCollisions()
        {
            if (colliders.Count <= 1) return;

            //from the first one to previous last(penultimate)
            for (int i = 0; i < colliders.Count - 1; i++)
            {
                //from the next to fist to last 
                for (int j = i + 1; j < colliders.Count; j++)
                {

                    //intesects and...
                    if (colliders[i].Boundary.Intersects(colliders[j].Boundary))
                    {
                        //was not in contact
                        if (!colliders[i].IsContacting(colliders[j]))
                        {
                            colliders[i].Enter(colliders[j]);
                            colliders[j].Enter(colliders[i]);
                            continue;
                        }

                        if (colliders[i].IsContacting(colliders[j]))
                        {
                            colliders[i].Stay(colliders[j]);
                            colliders[j].Stay(colliders[i]);
                            continue;
                        }
                    }
                    //not intersect
                    else
                    {
                        if (colliders[i].IsContacting(colliders[j]))
                        {
                            colliders[i].Exit(colliders[j]);
                            colliders[j].Exit(colliders[i]);
                            continue;
                        }
                    }




                }
            }
        }




    }
}
