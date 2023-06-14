using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ECS.Core.Components.Renderers;

namespace ECS._Game.GameObjects
{
    //Meio merda mas... sem tempo, irmão.
    class SnowController : GameComponent
    {
        private float weatherSpeed = 0.5f;
        private float elapsed = 0;
        public List<Renderer> rendersSnowing;

        public static SnowController instance; 

        public SnowController(Game game) : base(game)
        {
            instance = this;
            rendersSnowing = new List<Renderer>();
        }

        public void AddRenderer(Renderer renderer)
        {
            rendersSnowing.Add(renderer);
        }

        public void RemoveRenderer(Renderer renderer)
        {
            rendersSnowing.Remove(renderer);
        }


        public override void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Renderer renderer in rendersSnowing)
            {
                renderer.RenderMethod.effect.Parameters["gameTime"].SetValue(elapsed);
                renderer.RenderMethod.effect.Parameters["weatherSpeed"].SetValue(weatherSpeed);

            }


            base.Update(gameTime);
        }


    }
}
