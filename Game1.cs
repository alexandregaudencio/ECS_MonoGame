using ECS.Core.BaseObject;
using ECS.Core.BaseObject.House;
using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
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

        //private WindMill windMill;
        //private WindMill windMill2;
        private House house;
        private Camera camera;
        private CameraController cameraController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            camera = new Camera(this, new Vector3(100, 50,0));
            cameraController = new CameraController(this, camera);

            floor = new Plane(this, camera, Color.DarkGreen);
            floor.Transform.SetScale(Vector3.One * 1000);

            //house = new House(this, camera);
            //windMill = new WindMill(this, camera, new Vector3(0,0,30 ));
        }

        protected override void Initialize()
        {

            Components.Add(camera);
            Components.Add(cameraController);
            Components.Add(floor);
            //Components.Add(house);
            //Components.Add(windMill);

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

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1)) cameraController.SetCameraTarget(house.Transform);
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0)) cameraController.SetCameraTarget(new Transform(this));
            base.Update(gameTime);



        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}