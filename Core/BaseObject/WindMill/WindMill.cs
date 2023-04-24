using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECS.Core.BaseObject
{
    public class WindMill : Entity
    {

        //private WindBaldes windBaldes;
        private Cuboid cuboid;
        private Cuboid cuboid2;

        public WindMill(Game game, ICamPerspective camPerspective) : base(game)
        {
            //windBaldes = new WindBaldes(game, camPerspective);
            //windBaldes.Transform.Translate(Vector3.Up * 3);

            cuboid = new Cuboid(game, camPerspective);
            cuboid.Transform.SetScale(new Vector3(2, 7, 3));
            //cuboid.Transform.Translate(Vector3.Up * 7);

            cuboid2 = new Cuboid(game, camPerspective);
            cuboid2.Transform.SetScale(Vector3.One*3);
            //cuboid2.Transform.Translate(Vector3.Up*cuboid2.Transform.Scale.Y);
            cuboid2.Color = Color.Red;
           
            AddChild(/*windBaldes, */cuboid, cuboid2);

        }

        public override void Initialize()
        {
            //Game.Components.Add(windBaldes);
            Game.Components.Add(cuboid); 
            Game.Components.Add(cuboid2);

            Transform.Translate(Vector3.Up * 3);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Transform.Translate(Vector3.Left);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Transform.Translate(Vector3.Right);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Transform.Translate(Vector3.Forward);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Transform.Translate(Vector3.Backward);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Transform.RotateY(0.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Transform.RotateY(-0.1f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                Transform.IncreaseScale(Vector3.Right* 1.1f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Transform.IncreaseScale(Vector3.Right*-1.1f);
            }

            base.Update(gameTime);
        }

    }
}
