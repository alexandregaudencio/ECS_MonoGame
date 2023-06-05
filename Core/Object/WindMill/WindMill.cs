using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Object;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ECS.Core.BaseObject
{
    public class WindMill : Entities.Entity
    {

        private WindBaldes windBaldes;

        private Box cuboid;
        private Random random = new Random();
        private int RandomColorIndex => random.Next(0, 255);

        private Color RandomColor => new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex);

        public WindMill(Game game, ICameraPerspective camPerspective, Vector3 position) : base(game)
        {
            Transform.Translate(position);

            cuboid = new Box(game, camPerspective);
            cuboid.Transform.SetScale(new Vector3(5, 10, 5));
            cuboid.Transform.Translate(Vector3.UnitY * 10);

            windBaldes = new WindBaldes(game, camPerspective);
            windBaldes.Transform.Translate(new Vector3(5.1f, 15, 0));

            AddChild(windBaldes, cuboid);
        }

        public override void Initialize()
        {

            Game.Components.Add(cuboid);
            Game.Components.Add(windBaldes);
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            windBaldes.Transform.RotateX(0.001f * gameTime.ElapsedGameTime.Milliseconds);



            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Transform.RotateY(0.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Transform.RotateY(-0.1f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Transform.Translate(Transform.World.Right);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Transform.Translate(Transform.World.Left);
            }



            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                Transform.IncreaseScale(Vector3.Right * 1.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Transform.IncreaseScale(Vector3.Right * -1.1f);
            }

            base.Update(gameTime);
        }

    }
}
