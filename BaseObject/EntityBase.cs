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
        public Transform transform { get; set; }

        public EntityBase(Game game) : base(game)
        {

            guid = Guid.NewGuid();
            Console.WriteLine(guid);

        }


    }
}
