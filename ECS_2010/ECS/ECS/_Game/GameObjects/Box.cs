using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;

namespace ECS._Game.GameObjects
{
    public class Box : GameObject
    {
        private Texture secondTexture;
        private string secondTexturePath = "Textures/madeira-neve";
        private float weatherSpeed = 0.5f;
        private float elapsed = 0;

        public Box(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Cuboid(Color.White, "madeira", "lerpedTextures"));

            Renderer.SetActive(true);
            Collider.SetActive(true);

            

        }

        public override void Initialize()
        {
            Collider.SetVisible(true);

            base.Initialize();
        }

        protected override void LoadContent()
        {
           secondTexture = Game.Content.Load<Texture>(@secondTexturePath);
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
