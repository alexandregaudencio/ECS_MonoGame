using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ECS.Core.BaseObject
{
    public class WindMill : Entity
    {

        //private WindBaldes windBaldes;
        private List<Shape> blades = new List<Shape>();

        private Cuboid cuboid;
        private Random random = new Random();
        private int RandomColorIndex => random.Next(0, 255);

        public WindMill(Game game, ICamPerspective camPerspective) : base(game)
        {
            //windBaldes = new WindBaldes(game, camPerspective);
            //windBaldes.Transform.Translate(Vector3.Up * 3);
            GenerateBlades(game, camPerspective);

            cuboid = new Cuboid(game, camPerspective);
            cuboid.Transform.SetScale(new Vector3(2, 5, 2));

            //Transform.Translate(Vector3.Up * 20);

            AddChild(cuboid);
            AddChild(blades);
        }

        public override void Initialize()
        {

            Game.Components.Add(cuboid);
            foreach (Shape blade in blades)
            {
                Game.Components.Add(blade);
            }
            //Game.Components.Add(windBaldes);
            base.Initialize();
        }
        private void GenerateBlades(Game game, ICamPerspective camPerspective)
        {
            for (int i = 0; i < 4; i++)
            {
                Shape blade = new RightTriangle(game, camPerspective);
                //blade.Transform.IncreaseScale(new Vector3(2, 7, 2));
                blade.Color = new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex);
                blade.Transform.RotateY(i*MathF.PI / 2);
                blade.Transform.RotateZ(MathF.PI / 2);
                blade.Transform.Translate(new Vector3(3,3,0));
                
                blades.Add(blade);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < 4; i++)
            {
                blades[i].Transform.RotateY(0.001f * gameTime.ElapsedGameTime.Milliseconds);
            }

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
