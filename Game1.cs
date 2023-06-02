using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Managers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Plane = ECS.Core.Primitives.Plane;

namespace ECS
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        #region Keep Managers on Game1
        private readonly CollisionManager collisionManager;
        private readonly TimeManager timeManager;
        #endregion


        #region camera and cameraconfig on Scene
        private readonly Camera camera;
        private readonly CameraController cameraController;
        #endregion


        #region Objects - just for test
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
            timeManager =  new TimeManager(this);

            #region Objects Instances of test
            camera = new Camera(this, new Vector3(0, 10, 2));
            cameraController = new CameraController(this, camera);
            
            floor = new Plane(this, camera, Color.DarkBlue);
            floor.Transform.SetScale(Vector3.One * 1000);
            box = new Box(this, camera);
            box2 = new Box(this, camera);
            box2.SetObjectOnFloorY();
            box.SetObjectOnFloorY();
            box2.Transform.Translate(Vector3.UnitX * 4);
            box2.MovementControl.Active = true;

            sphere = new Sphere(this, camera);
            sphere.SetObjectOnFloorY();
            sphere.Transform.Translate(Vector3.UnitZ * 3);

            //box.Transform.IncreaseScale(Vector3.One * 2);
            //house = new House(this, camera);
            //windMill = new WindMill(this, camera, new Vector3(0,0,30 ));

            #endregion

        }

        protected override void Initialize()
        {
            
            Components.Add(collisionManager);
            Components.Add(timeManager);

            #region Add Instances of test
            Components.Add(camera);
            Components.Add(cameraController);
            Components.Add(floor);
            Components.Add(box);
            Components.Add(box2);
            Components.Add(sphere);
            #endregion

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


            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0)) cameraController.SetCameraTarget(sphere.Transform);
            base.Update(gameTime);



        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }




    }
}