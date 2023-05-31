using ECS.Core.BaseObject;
using ECS.Core.BaseObject.House;
using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderer;
using ECS.Core.GameObject;
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
        //private WindMill windMill2;
        //private House house;
        private  Box box;
        private Camera camera;
        private CameraController cameraController;

        private readonly CollisionManager collisionManager;
        private Collider collider;
        Collider collider1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            camera = new Camera(this, new Vector3(30, 10,0));
            cameraController = new CameraController(this, camera);

            floor = new Plane(this, camera, Color.DarkGreen);
            floor.Transform.SetScale(Vector3.One * 1000);

            box = new Box(this, camera, "");

            collider = new Collider(this, camera, true);
            collider1 = new Collider(this, camera, false);
            collider1.Transform.Translate(Vector3.UnitZ * 10);
            collisionManager = new CollisionManager(this);
            collisionManager.AddCollider(collider);
            collisionManager.AddCollider(collider1);
            //house = new House(this, camera);
            windMill = new WindMill(this, camera, new Vector3(0,0,30 ));
        }

        protected override void Initialize()
        {

            Components.Add(camera);
            Components.Add(cameraController);
            Components.Add(floor);
            //Components.Add(box);
            Components.Add(collisionManager);
            Components.Add(collider);
            Components.Add(collider1);

            //Components.Add(house);
            Components.Add(windMill);

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

            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad1)) cameraController.SetCameraTarget(modelRenderer.Transform);
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0)) cameraController.SetCameraTarget(collider.Transform);
            base.Update(gameTime);



        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }




    }
}