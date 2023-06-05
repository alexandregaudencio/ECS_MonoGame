using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using ECS.Core.Managers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ECS._Game.GameObjects.WindMill
{
    public class WindMill : GameObject
    {

        private WindBaldes windBaldes;
        private Box cuboid;

        private Random random = new Random();
        private int RandomColorIndex => random.Next(0, 255);
        private Color RandomColor => new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex);

        public WindMill(Game game, ICameraPerspective camPerspective, Vector3 position) : base(game, camPerspective)
        {

            Transform.Translate(position);
            Transform.SetScale(Vector3.One * 2);

            cuboid = new Box(game, camPerspective);
            windBaldes = new WindBaldes(game, camPerspective);
            Renderer = new Renderer(game, camPerspective, new Cuboid(Color.Wheat));

            cuboid.Transform.SetScale(new Vector3(1, 2, 1));
            cuboid.Transform.Translate(Vector3.UnitY/2f);
            windBaldes.Transform.Translate(new Vector3(1.1f, 1, 0));
            SetObjectOnFloorY();


        }

        public override void Initialize()
        {
            AddChild(cuboid);
            AddChild(windBaldes);

            Game.Components.Add(cuboid);
            Game.Components.Add(windBaldes);

            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            windBaldes.Transform.RotateX(0.001f * gameTime.ElapsedGameTime.Milliseconds);

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
