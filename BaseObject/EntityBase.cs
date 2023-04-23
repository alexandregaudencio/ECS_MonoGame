using ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Transactions;

namespace ECS.BaseObject
{
    public class EntityBase : DrawableGameComponent
    {
        public readonly Guid guid;
        public Transform Transform { get; set; } = new Transform();

        public EntityBase(Game game ) : base(game)
        {
            Transform = new Transform();

            guid = Guid.NewGuid();
            Console.WriteLine(guid);

        }


    }
}
