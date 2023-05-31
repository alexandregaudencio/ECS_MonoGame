using ECS.Core.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace ECS.Core.Entities
{
    public abstract class Entity : DrawableGameComponent, IComposite<Entity>
    {
        public readonly Guid guid;
        public Transform Transform { get; set; }
        public List<Entity> Childs { get; set; } = new List<Entity>();

        public Entity(Game game) : base(game)
        {
            Transform = new Transform(game);
            guid = Guid.NewGuid();
            PassTransformToChilds();
        }

        public void AddChild(params Entity[] objs)
        {
            foreach (Entity item in objs)
            {
                Childs.Add(item);

            }
           
            PassTransformToChilds();


        }
        public void AddChild(IEnumerable<Entity> objs)
        {
            foreach (Entity item in objs)
            {
                Childs.Add(item);
            }

            PassTransformToChilds();

        }

        public void RemoveChild(int indexOf)
        {
            if (Childs == null)
                throw new ArgumentNullException($"Childs in entity {guid} is empty.");
            Childs.RemoveAt(indexOf);
        }

        public override void Initialize()
        {
            Game.Components.Add(Transform);
            base.Initialize();
        }

        private void PassTransformToChilds()
        {
            if (Childs.Count == 0) return;
            foreach (Entity entity in Childs)
            {
                entity.Transform.SetParent(Transform);
            }
        }



    }
}
