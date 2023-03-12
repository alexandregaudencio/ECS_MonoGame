using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components
{
    public class Transform<T>: GameComponent where T : struct
    {
        private T position;
        private T rotation;
        private T scale;

        public T Scale { get => scale; set => scale = value; }
        public T Position { get => position; set => position = value; }
        public T Rotation { get => rotation; set => rotation = value; }

        public Transform(Game game, T position , T rotation, T scale) : base(game) 
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale; 
        }
        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }



    }
}
