using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ECS._Game.GameObjects.House
{
    internal class HoofTriangleObject : GameObject
    {
        private Texture secondTexture;
        private string secondTexturePath = "Textures/madeira-neve";
        private float weatherSpeed = 1f;
        private float elapsed = 0;

        public HoofTriangleObject(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new HoofTriangle(Color.White, "madeira", "lerpedTextures"));
            SnowController.instance.AddRenderer(this.Renderer);
        }

        protected override void LoadContent()
        {
            secondTexture = Game.Content.Load<Texture>(string.Concat(@secondTexturePath));
            base.LoadContent();
        }



        public override void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Renderer.RenderMethod.effect.Parameters["gameTime"].SetValue(elapsed);
            Renderer.RenderMethod.effect.Parameters["weatherSpeed"].SetValue(weatherSpeed);
            Renderer.RenderMethod.effect.Parameters["secondTexture"].SetValue(secondTexture);

            base.Update(gameTime);
        }
    }
}
