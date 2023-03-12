using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Globalization;

namespace ECS.Components
{
    public class Renderer : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Layering layering;

        private Texture2D Texture { get; set; }
        private Color Color { get; set; }
        //private Point point { get; set; }
        private Rectangle Rectangle { get; set; }
        private Transform<Vector2> Transform { get; set; }
        private string LayerName { get; set; }
        //private Vector2 position;
        //private Vector2 speed;
        //private float scale { get; set; }

        public Renderer(Game game, string texturePath, Transform<Vector2> transform, string layerName, Layering layering) : base(game)
        {

            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            Texture = game.Content.Load<Texture2D>(@""+texturePath);
            Transform = transform;
            this.layering = layering;
            LayerName = layerName;
            SetRectangle(Texture.Bounds);
            //scale = 1.0f;
            Color = Color.White;
            //else SetRectangle(new Rectangle(new Point(20, 20), new Point(20, 20)));
            //this.position = position;
            //this.size = new Point(100, 100);
            //this.speed = new Vector2(10, 10)*10;

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //this.position += this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            //if (this.position.X <= 0)
            //{
            //    speed.X *= -1;
            //}
            //else if (this.position.X + this.size.X >= base.Game.Window.ClientBounds.Width)
            //{
            //    this.speed.X *= -1;
            //}

            //if (this.position.Y < 0)
            //{
            //    this.speed.Y *= -1;
            //}
            //else if (this.position.Y + this.size.Y >= Game.Window.ClientBounds.Height)
            //{
            //    this.speed.Y *= -1;
            //}

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Transform.Position, Rectangle, Color, Transform.Rotation.Length(), Vector2.Zero, Transform.Scale.Length(), SpriteEffects.None, layering.GetLayerByName(LayerName));
            spriteBatch.End();
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