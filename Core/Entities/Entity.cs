using ECS.Core.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Transactions;

namespace ECS.Core.Entities
{
    public abstract class Entity : DrawableGameComponent, IComposite<Entity>
    {
        public readonly Guid guid;
        public Transform Transform { get; set; } = new Transform();
        public List<Entity> Childs { get; set; } = new List<Entity>();


        public Entity(Game game) : base(game)
        {
            guid = Guid.NewGuid();
            Transform.TransformChanged += ParentTransformChilds;
        }

        public void AddChild(params Entity[] objs)
        {
            foreach (Entity item in objs)
            {
                Childs.Add(item);

            }

        }

        public void AddChild(IEnumerable<Entity> objs)
        {
            foreach (Entity item in objs)
            {
                Childs.Add(item);

            }
        }
        public void RemoveChild(int indexOf)
        {
            if (Childs == null)
                throw new ArgumentNullException($"Childs in entity {guid} is empty.");
            Childs.RemoveAt(indexOf);
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        private void ParentTransformChilds(Transform transform)
        {
            if (Childs == null) return;

            foreach (Entity entity in Childs)
            {

                entity.Transform?.Transformate(transform);
            }
        }


    }
}
