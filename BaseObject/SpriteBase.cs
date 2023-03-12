using ECS.Components;
using Microsoft.Xna.Framework;
using ECS.BaseObject;

namespace ECS.BaseObject
{
    public  class SpriteBase : EntityBase
    {
        private Game game { get; set; }
        protected Transform<Vector2> Transform { get; set; }  
        protected Renderer2D Renderer { get; set; }
        protected string TexturePath { get; set; }


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


        private float speedx = 3;
        public override void Update(GameTime gameTime)
        {

            #region so para brincar

            Transform.Rotation += 0.001f*gameTime.ElapsedGameTime.Milliseconds;

            
            if (Transform.Position.X + 100 > game.Window.ClientBounds.Width || Transform.Position.X - 100 < 0)
            {
                speedx = -speedx;
            }

            Transform.Position += new Vector2(speedx, 0);

            #endregion

            base.Update(gameTime);
        }



    }
}
