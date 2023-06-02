using ECS._Game._Scenes;
using ECS.Core.Components.Collision;
using ECS.Core.Managers;
using ECS.Core.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ECS._Game
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        #region Keep Managers on Game1
        private readonly CollisionManager collisionManager;
        private readonly TimeManager timeManager;
        private readonly SceneManager sceneManager;
        #endregion

        Scene sceneTest;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            collisionManager = new CollisionManager(this);
            timeManager = new TimeManager(this);
            sceneManager = new SceneManager(this);

            sceneTest = new SceneTest(this, "Scene Test");


        }

        protected override void Initialize()
        {

            Components.Add(collisionManager);
            Components.Add(timeManager);
            Components.Add(sceneManager);

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

            base.Update(gameTime);



        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            base.Draw(gameTime);
        }




    }
}