using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.BaseObject
{
    public class WindBaldes : Entity
    {

        private List<Shape> blades = new List<Shape>();
        private Vector3 bladeScale = new Vector3(1, 0, -0.4f);
        public WindBaldes(Game game, ICamPerspective camPerspective) : base(game)
        {

            GenerateBlades(game, camPerspective);
            AddChild(blades);


        }

        public override void Initialize()
        {
            Transform.RotateZ(MathF.PI / 2);

            foreach (Shape blades in blades)
            {
                Game.Components.Add(blades);
                
            }
            

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //Transform.RotateX(0.000001f * gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }



        private void GenerateBlades(Game game, ICamPerspective camPerspective)
        {
            for (int i = 0; i < 4; i++)
            {
                Shape blade = new RightTriangle(game, camPerspective);
                blade.Transform.IncreaseScale(bladeScale);
                blade.Transform.RotateY(i * (float)Math.PI / 2);
                blade.Transform.RotateZ(Transform.Rotation.Z);

                blades.Add(blade);
            }
        }

    }
}
