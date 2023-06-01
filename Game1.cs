using ECS.Core.BaseObject;
using ECS.Core.BaseObject.House;
using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderer;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Plane = ECS.Core.Primitives.Plane;

namespace ECS
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly CollisionManager collisionManager;
        private readonly Camera camera;
        private readonly CameraController cameraController;

        #region Objects
        private readonly Plane floor;
        //private WindMill windMill;
        //private WindMill windMill2;
        //private House house;
        private readonly Box box;
        private readonly Box box2;
        private Sphere sphere;
        #endregion


        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            collisionManager = new CollisionManager(this);

            camera = new Camera(this, new Vector3(5, 10, 0));
            cameraController = new CameraController(this, camera);

            floor = new Plane(this, camera, Color.DarkBlue);
            floor.Transform.SetScale(Vector3.One * 1000);
            box = new Box(this, camera);
            box2 = new Box(this, camera);
            box2.SetObjectOnFloorY();
            box.SetObjectOnFloorY();
            box2.Transform.Translate(Vector3.UnitX * 4);
            box2.movivel = false;

            sphere = new Sphere(this, camera);
            sphere.SetObjectOnFloorY();
            sphere.Transform.Translate(Vector3.UnitZ * 3);
            //box.Transform.IncreaseScale(Vector3.One * 2);

            //collisionManager.AddColliders(collider, collider1, collider2, collider3);
            //collisionManager.AddColliders(box.collider);
            //house = new House(this, camera);
            //windMill = new WindMill(this, camera, new Vector3(0,0,30 ));
        }

        protected override void Initialize()
        {

            Components.Add(camera);
            Components.Add(cameraController);
            Components.Add(collisionManager);
            Components.Add(floor);
            Components.Add(box);
            Components.Add(box2);
            Components.Add(sphere);
            //Components.Add(collisionManager);

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

            //if (Keyboard.GetState().IsKeyDown(Keys.NumPad1)) cameraController.SetCameraTarget(modelRenderer.Transform);
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0)) cameraController.SetCameraTarget(box.Transform);
            base.Update(gameTime);



        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }




    }
}