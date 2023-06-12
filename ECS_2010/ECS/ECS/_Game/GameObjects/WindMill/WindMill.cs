using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Managers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using ECS.Core;

namespace ECS._Game.GameObjects.WindMill
{
    public class WindMill : GameObject, IActivable
    {
        public bool Active { get; set; }
        public void SetActive(bool active) { Active = active; }

        private WindBaldes windBaldes;
        private Box cuboid;

        private Random random = new Random();
        private int RandomColorIndex {get{ return random.Next(0, 255);}}
        private Color RandomColor { get { return new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex); } }

        public WindMill(Game game, ICameraPerspective camPerspective) : base(game, camPerspective)
        {
            Renderer = new Renderer(game, camPerspective, new Cuboid(Color.Wheat, "", "grayscale"));
            Active = false;
            Transform.SetScale(Vector3.One * 2);


            cuboid = new Box(game, camPerspective);
            cuboid.Renderer.RenderMethod.SetColor(Color.Gray);

            windBaldes = new WindBaldes(game, camPerspective);


            cuboid.Transform.SetScale(new Vector3(1, 2, 1));
            cuboid.Transform.Translate(-Vector3.UnitY/2f);
            windBaldes.Transform.Translate(new Vector3(1.1f, 1, 0));


            this.Renderer.SetActive(false);
            cuboid.Collider.SetActive(false);


        }

        public override void Initialize()
        {
            Transform.SetMinYOnFloor();

            AddChild(cuboid);
            AddChild(windBaldes);

            Game.Components.Add(cuboid);
            Game.Components.Add(windBaldes);

            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            windBaldes.Transform.RotateX(0.001f * gameTime.ElapsedGameTime.Milliseconds);
            if (!Active) return;

            float speed = 2f * Time.Instance.ElapsedTime;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Transform.RotateY(speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Transform.RotateY(-speed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Transform.Translate(Transform.World.Right* speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Transform.Translate(Transform.World.Left* speed);
            }



            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                Transform.IncreaseScale(Vector3.Right * 1.1f* speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Transform.IncreaseScale(Vector3.Right * -1.1f* speed);
            }

            base.Update(gameTime);
        }

    }
}
