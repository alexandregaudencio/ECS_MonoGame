using ECS.Core.Components.Cam;
using ECS.Core.Entity;
using ECS.Core.Primitives;
using ECS.Core.Util.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace ECS.Core.BaseObject
{
    public class WindBaldes : Entity.Entity
    {

        private List<Shape> blades = new List<Shape>();
        private Vector3 bladeScale = new Vector3(3, 0, 1.5f) * 5;

        public WindBaldes(Game game, ICameraPerspective camPerspective) : base(game)
        {

            GenerateBlades(game, camPerspective);
            AddChild(blades);


        }

        public override void Initialize()
        {

            foreach (Shape blade in blades)
            {
                Game.Components.Add(blade);
            }

            SetBladesLocation();

            base.Initialize();
        }




        private void GenerateBlades(Game game, ICameraPerspective camPerspective)
        {
            for (int i = 0; i < 4; i++)
            {
                Shape blade = new RightTriangle(game, camPerspective, new Color().Random(), "madeira");
                blade.Transform.SetScale(bladeScale);

                blades.Add(blade);
            }
        }

        private void SetBladesLocation()
        {
            for (int i = 0; i < 4; i++)
            {
                blades[i].Transform.RotateY(i * MathF.PI / 2);
                blades[i].Transform.RotateZ(MathF.PI / 2);

            }

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }




    }
}
