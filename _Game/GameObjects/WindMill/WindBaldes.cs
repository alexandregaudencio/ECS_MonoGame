using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Entities;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace ECS._Game.GameObjects.WindMill
{
    public class WindBaldes : Entity
    {

        private List<Triangle> blades = new List<Triangle>();
        private Vector3 bladeScale = new Vector3(2.5f, 0, 1.1f);

        public WindBaldes(Game game, ICameraPerspective camPerspective) : base(game)
        {

            GenerateBlades(game, camPerspective);

            AddChild(blades);

        }

        public override void Initialize()
        {

            foreach (GameObject blade in blades)
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
                Triangle blade = new Triangle(game, camPerspective);
                blade.Transform.SetScale(bladeScale);
                blade.Renderer.SetActive(true);
                blade.Collider.SetActive(false);

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
