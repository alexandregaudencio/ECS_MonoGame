using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Object;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework;
using ECS.Core.Managers;

namespace ECS._Game.GameObjects
{
    class Flag : GameObject
    {
        Pole pole;
        public Flag(Game game, ICameraPerspective camPerspective)  : base(game, camPerspective)
        {
            Transform.SetScale(Vector3.One / 8);
            Transform.IncreaseScale(Vector3.UnitX *0.2f);
            Transform.Translate(Vector3.One * 8); 
            Transform.RotateX(MathHelper.PiOver2);
            Transform.Translate(new Vector3(5, 0, -5)*2);

            Renderer = new Renderer(game, camPerspective, new HeightMapGrid(Vector2.One * 30, "bandeira-brasil", "", "linearWave"));
            pole = new Pole(game, camPerspective);
            pole.Transform.SetScale(new Vector3(1,5,40));
            pole.Transform.Translate(-Vector3.UnitX*15);
            pole.Transform.Translate(Vector3.UnitZ * 15);

        }

        public override void Initialize()
        {
            AddChild(pole);
            Game.Components.Add(pole);
            base.Initialize();
        }


        //float elapsed = 0;
        public override void Update(GameTime gameTime)
        {


            Renderer.RenderMethod.effect.Parameters["time"].SetValue(Time.Instance.ReleasedTime);
            base.Update(gameTime);
        }


        
    }
}
