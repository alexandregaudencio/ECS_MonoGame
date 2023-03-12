using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Components
{
    public class Renderer2D : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D Texture { get; set; }
        private Color Color { get; set; }
        private Rectangle Rectangle { get; set; }
        private Transform<Vector2> Transform { get; set; }
        private string LayerName { get; set; }

        public Renderer2D(Game game, string textureName, Transform<Vector2> transform, string layerName) : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            Texture = game.Content.Load<Texture2D>(textureName);
            Transform = transform;
            LayerName = layerName;
            SetRectangle(Texture.Bounds);
            Color = Color.White;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Transform.Position, Rectangle, Color, Transform.Rotation, Rectangle.Center.ToVector2(), Transform.Scale, SpriteEffects.None, 0/* Layering.Layers[LayerName]*/);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void SetRectangle(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

    }
}