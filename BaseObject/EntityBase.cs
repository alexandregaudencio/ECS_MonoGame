using Microsoft.Xna.Framework;
using System;


namespace Project1.BaseObject
{
    public class EntityBase : GameComponent
    {
        private readonly Guid guid = Guid.NewGuid();

        public EntityBase(Game game) : base(game)
        {
            Console.WriteLine(guid);

        }

    }
}
