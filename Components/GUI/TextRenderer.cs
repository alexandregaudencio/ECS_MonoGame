using ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Components.GUI
{
    public class TextRenderer : DrawableGameComponent
    {
        private string text = "";
        private SpriteBatch spriteBatch;
        private SpriteFont font { get; set; }
        private Color Color { get; set; }
        private Transform<Vector2> Transform { get; set; }
        private string LayerName { get; set; }

        public string Text { get => text; set => text = value; }


        public TextRenderer(Game game,string text, string fontFileName, Transform<Vector2> transform, string layerName) : base(game)
        {
            this.Text = text;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            font = game.Content.Load<SpriteFont>(fontFileName);
            Transform = transform;
            LayerName = layerName;
            Color = Color.White;

        }



        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Text, Transform.Position, Color, Transform.Rotation, Vector2.Zero, Transform.Scale, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);

        }

        public void SetColor(Color color)
        {
            Color = color;
        }


    }
}
