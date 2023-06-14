using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Managers;

namespace ECS._Game.GameObjects
{
    class Ocean : GameObject
    {

        public Ocean(Game game, ICameraPerspective camPerspective)
            : base(game, camPerspective)
        {
            Renderer = new Renderer(game, camPerspective, new HeightMapGrid(Vector2.One * 100, "water", "", "waterWave"));
            Transform.IncreaseScale(new Vector3(1, 0, 1)*3);
            Transform.Translate(Vector3.UnitY * -3);
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            Renderer.RenderMethod.effect.Parameters["time"].SetValue(Time.Instance.ReleasedTime);
            base.Update(gameTime);
        }

    }
}
