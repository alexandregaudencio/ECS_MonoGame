//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;

//namespace ECS.Components
//{
//    public class Renderer2D : DrawableGameComponent, IAnimationRenderUpdate
//    {
//        private SpriteBatch spriteBatch;
//        public Texture2D Texture { get; set; }
//        private Color Color { get; set; }
//        public Rectangle Rectangle { get; set; }
//        private Transform Transform { get; set; }
//        private string LayerName { get; set; }

//        private SpriteEffects spriteEffects;
//        public SpriteEffects SpriteEffects { get => spriteEffects; set => spriteEffects = value; }



//        public Renderer2D(Game game, string texturePath, Transform transform, string layerName) : base(game)
//        {
//            spriteBatch = new SpriteBatch(game.GraphicsDevice);
//            Texture = game.Content.Load<Texture2D>(texturePath);
//            Transform = transform;
//            LayerName = layerName;
//            SetRectangle(Texture.Bounds);
//            Color = Color.White;
//            SpriteEffects = SpriteEffects.None;
//        }

//        public override void Draw(GameTime gameTime)
//        {
//            spriteBatch.Begin();
//            spriteBatch.Draw(Texture, Transform.Vect2Position(),
//                Rectangle, Color,
//                Transform.AngleDegrees,
//                Rectangle.Center.ToVector2(),
//                Transform.Vect2Scale(),
//                SpriteEffects,
//                0/* Layering.Layers[LayerName]*/
//            ); 
//            spriteBatch.End();
//            base.Draw(gameTime);
//        }

//        public void SetColor(Color color)
//        {
//            Color = color;
//        }

//        //public void SetRectangle(Point location, Point size)
//        //{
//        //    Rectangle rectangle = new Rectangle(location, size);
//        //    Rectangle = rectangle;
//        //}


//        public void SetRectangle(Rectangle rectangle)
//        {

//            Rectangle = rectangle;
//        }

//        public void SetTexture2D(Texture2D texture2D)
//        {
//            Texture = texture2D;

//        }
//    }
//}