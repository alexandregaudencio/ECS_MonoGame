using ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ECS.Components.GUI
{
    [Flags]
    public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }

    public class TextRenderer : DrawableGameComponent
    {
        private string text = "";
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont { get; set; }
        private Color Color { get; set; }
        private Transform Transform { get; set; }
        private string LayerName { get; set; }
        private Rectangle rectangle { get; set; }
        private Alignment alignment = Alignment.Center;
        private Vector2 size;
        private Vector2 origin;

        public string Text => text;

        public Alignment Alignment { get => alignment; set => alignment = value; }

        public event Action propertyChanged;

        public TextRenderer(Game game,string text, string fontFileName, Transform transform, string layerName) : base(game)
        {
            propertyChanged += UpdateOrigin;

            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            spriteFont = game.Content.Load<SpriteFont>(fontFileName);
            Transform = transform;
            LayerName = layerName;
            Color = Color.White;
            rectangle = spriteFont.Texture.Bounds;

            SetText(text);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DrawString();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetColor(Color color)
        {
            Color = color;

        }

        public void SetAlignment(Alignment alignment)
        {
            this.alignment = alignment;
            propertyChanged?.Invoke();

        }

        public void SetText(string text)
        {
           this.text = text;
            propertyChanged?.Invoke();

        }

        public void DrawString()
        {
            spriteBatch.DrawString(spriteFont, 
                text, Transform.Vect2Position(), 
                Color, Transform.Vect2Rotation().Length(), 
                origin, Transform.Vect2Scale(), 
                SpriteEffects.None, 0);
        }

        private void UpdateOrigin()
        {
            size = spriteFont.MeasureString(text);
            origin = size * 0.5f;

            if (alignment.HasFlag(Alignment.Left))
                origin.X += rectangle.Width / 2 - size.X / 2;

            if (alignment.HasFlag(Alignment.Right))
                origin.X -= rectangle.Width / 2 - size.X / 2;

            if (alignment.HasFlag(Alignment.Top))
                origin.Y += rectangle.Height / 2 - size.Y / 2;

            if (alignment.HasFlag(Alignment.Bottom))
                origin.Y -= rectangle.Height / 2 - size.Y / 2;
        }



    }
}
