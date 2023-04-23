using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECS.Primitives;
using ECS.Components.Cam;
using Microsoft.Xna.Framework;
using Plane = ECS.Primitives.Plane;
using ECS.Components;

namespace ECS
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        //private EquilateralTriangle tr;
        //private PatoSprite patoSprite;
        //private TextBase newText;
        //private BoxSprite Box;
        private Cuboid cube;

        private Plane plane;
        private Camera camera;
        private CameraController cameraController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            camera = new Camera(this, new Transform(Vector3.Zero));
            cameraController = new CameraController(this, camera);



        }

        protected override void Initialize()
        {
            plane = new Plane(this, Vector3.Zero, camera);
            cube = new Cuboid(this, Vector3.Zero, camera);

            //patoSprite = new PatoSprite(this, "pato", new Vector3(100,0,0), Vector3.Zero, Vector3.One/2);
            //Boxj = new BoxSprite(this, "Images/Boxes/box1", new Vector3(15, 15, 0), Vector3.Zero, Vector3.One);



            //Components.Add(tr);
            //Components.Add(patoSprite);
            //Components.Add(newText);
            //Components.Add(Box);
            Components.Add(plane);
            Components.Add(cube);
            Components.Add(cameraController);
            //Components.Add(camera);

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

            //newText.SetText(/*Box.animator2D.CurrentAnimation.CurrentFrame.ToString()*/ "HiH");


            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}