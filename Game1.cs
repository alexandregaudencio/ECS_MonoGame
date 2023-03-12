using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Components;
using System.Collections;
using Project1.BaseObject;
using Project1.GameObjects;
using System.IO;
using Project1.Components.GUI;

namespace ECS
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TextRenderer tRenderer;

        private PatoSprite patoSprite;
        private TextBase text;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            



        }

        protected override void Initialize()
        {
            patoSprite = new PatoSprite(this, "pato", Vector2.Zero, 0, 1);
            text = new TextBase(this,"message", Vector2.One, 0, 1);
            Components.Add(patoSprite);
            Components.Add(text);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}