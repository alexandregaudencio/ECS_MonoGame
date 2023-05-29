using ECS.Core.BaseObject;
using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Plane = ECS.Core.Primitives.Plane;

namespace ECS
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private Plane floor;

        private WindMill windMill;
        private WindMill windMill2;
        private Camera camera;
        private CameraController cameraController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            camera = new Camera(this, new Vector3(100, 50,0));
            cameraController = new CameraController(this, camera);

            windMill = new WindMill(this, camera, new Vector3(0,0,30 ));
            windMill2 = new WindMill(this, camera, new Vector3(0,0,-30));

        }

        protected override void Initialize()
        {
            floor = new Plane(this, camera);
            floor.Transform.SetScale(Vector3.One * 100);
            floor.Color = Color.DarkGreen;

            Components.Add(camera);
            Components.Add(cameraController);
            Components.Add(floor);
            Components.Add(windMill);
            Components.Add(windMill2);

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

            //plane.Transform.RotateY(MathHelper.ToRadians(1)) ;

            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}