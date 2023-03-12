using ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.BaseObject
{
    public  class SpriteBase : EntityBase
    {
        private Game game { get; set; }

        private Transform<Vector2> Transform { get; set; }  
        public Renderer2D Renderer { get; set; }
        private string TexturePath { get; set; }

        public SpriteBase(Game game, string texturePath, Vector2 position, float rotation, float scale ) : base(game)
        {
            this.game = game;
            TexturePath = texturePath;
            Transform = new Transform<Vector2>( position, rotation, scale);
            //TODO: corrigir Layering
            Renderer = new Renderer2D(game, TexturePath, Transform, "");

        }

        public override void Initialize()
        {
            game.Components.Add(Renderer);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Transform.Rotation += 0.001f*gameTime.ElapsedGameTime.Milliseconds;
            base.Update(gameTime);
        }



    }
}
