using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.BaseObject;
using ECS.Entities;
using System;
using Microsoft.Xna.Framework.Content;
using ECS.Primitives;

using System.Collections.Generic;

namespace ECS
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        //private EquilateralTriangle tr;
        private PatoSprite patoSprite;
        private TextBase newText;
        private BoxSprite Box;
        private Cuboid cube;
        private WireCuboid wireCuboid;
        private WirePlane wirePlane;

        private Primitives.Plane plane;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
        }

        protected override void Initialize()
        {
            patoSprite = new PatoSprite(this, "pato", new Vector3(100,0,0), Vector3.Zero, Vector3.One/2);
            Box = new BoxSprite(this, "Images/Boxes/box1", new Vector3(15, 15, 0), Vector3.Zero, Vector3.One);
            newText = new TextBase(this, "string", Vector3.One, Vector3.Zero, Vector3.One);
            //tr = new EquilateralTriangle(this, Vector3.Zero, 1, Color.Aqua);
            plane = new Primitives.Plane(this, Vector3.Zero, 5, Color.ForestGreen);
            cube = new Cuboid(this, Vector3.Zero, 1, Color.Green);
            wireCuboid = new WireCuboid(this, Vector3.Zero, 2, Color.Black);
            wirePlane = new WirePlane(this, Vector3.Zero, 10, Color.Black);


            //Components.Add(tr);
            Components.Add(patoSprite);
            Components.Add(newText);
            Components.Add(Box);
            Components.Add(plane);
            Components.Add(cube);
            Components.Add(wireCuboid);
            Components.Add(wirePlane);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();

        }

        protected override void UnloadContent()
        {
            Content.Unload();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();

            newText.SetText(Box.animator2D.CurrentAnimation.CurrentFrame.ToString());


            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}