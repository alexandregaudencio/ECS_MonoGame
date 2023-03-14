﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.BaseObject;
using ECS.Entities;
using System;
using Microsoft.Xna.Framework.Content;

namespace ECS
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private PatoSprite patoSprite;
        private TextBase newText;

        private Random random = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            



        }

        protected override void Initialize()
        {
            patoSprite = new PatoSprite(this, "pato", new Vector3(100,0,0), Vector3.Zero, Vector3.One/2);
            newText = new TextBase(this, " string", Vector3.One, Vector3.Zero, Vector3.One);
            Components.Add(patoSprite);
            Components.Add(newText);

            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();

        }

        protected override void UnloadContent()
        {
            //patoSprite.Renderer.Texture.Dispose();
            Content.Unload();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();
            newText.SetText(gameTime.ElapsedGameTime.Milliseconds.ToString());
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}