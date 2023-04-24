using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Plane = ECS.Core.Primitives.Plane;
using ECS.Core.Components.Cam;
using ECS.Core.BaseObject;
using ECS.Core.Components;

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

        //private RightTriangle rightTriangle;
        //private Cube cube;
        private Plane plane;

        private WindMill windMill;
        private Camera camera;
        private CameraController cameraController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            camera = new Camera(this, new Transform(Vector3.One*50));
            cameraController = new CameraController(this, camera);

            windMill = new WindMill(this, camera);


        }

        protected override void Initialize()
        {
            plane = new Plane(this, camera);
            //plane.Transform.Scale = Vector3.One*15;

            //cube = new Cube(this, camera);
            //rightTriangle = new RightTriangle(this, camera);

            //patoSprite = new PatoSprite(this, "pato", new Vector3(100,0,0), Vector3.Zero, Vector3.One/2);
            //Boxj = new BoxSprite(this, "Images/Boxes/box1", new Vector3(15, 15, 0), Vector3.Zero, Vector3.One);
            //Components.Add(tr);
            //Components.Add(patoSprite);
            //Components.Add(newText);
            //Components.Add(Box);

            Components.Add(plane);
            //Components.Add(cube);
            //Components.Add(rightTriangle);

            Components.Add(windMill);
            Components.Add(cameraController);

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