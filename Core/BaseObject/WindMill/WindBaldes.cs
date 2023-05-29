using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace ECS.Core.BaseObject
{
    public class WindBaldes : Entity
    {

        private List<Shape> blades = new List<Shape>();
        private Vector3 bladeScale = new Vector3(14, 0, -0.4f);
        public WindBaldes(Game game, ICamPerspective camPerspective) : base(game)
        {

            GenerateBlades(game, camPerspective);
            AddChild(blades);

        }

        public override void Initialize()
        {
            Transform.RotateZ(MathF.PI / 2);
            Transform.Translate(Transform.Matrix.Up * 2.1f);
            Transform.RotateZ(-MathF.PI / 2);

            foreach (Shape blade in blades)
            {
                Game.Components.Add(blade);
            }
            SetBladesLocation();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Transform.RotateY(0.001f * gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }


        int randomColorIndex => new Random().Next(255);

        private void GenerateBlades(Game game, ICamPerspective camPerspective)
        {
            for (int i = 0; i < 4; i++)
            {
                Shape blade = new RightTriangle(game, camPerspective);
                blade.Transform.IncreaseScale(bladeScale);
                blade.Color = new Color(randomColorIndex, randomColorIndex, randomColorIndex);
                blade.Transform.RotateX(i * (float)(MathF.PI / 2));

                blades.Add(blade);
            }
        }

        private void SetBladesLocation()
        {
            for (int i = 0; i < 4; i++)
            {
                blades[i].Transform.RotateZ(i * MathF.PI / 2);

            }
        }


    }
}
