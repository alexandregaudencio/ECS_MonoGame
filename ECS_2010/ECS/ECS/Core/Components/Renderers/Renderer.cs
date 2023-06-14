using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    public class Renderer : Entity, IActivable
    {
        public RenderMethod RenderMethod { get; private set; }
        public readonly ICameraPerspective icameraPerspective;

        public bool Active { get; private set; } 
        public void SetActive(bool active) { Active = active; }

        public Renderer(Game game, ICameraPerspective icameraPerspective, RenderMethod renderMethod) : base(game)
        {
            Active = true;
            this.icameraPerspective = icameraPerspective;
            this.RenderMethod = renderMethod;
            renderMethod.SetRenderer(this);


        }

        protected override void LoadContent()
        {
            RenderMethod.Load();
            base.LoadContent();
        }

        public override void Initialize()
        {
            RenderMethod.Initialize();

            Game.GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
            };
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Active) return;
            RenderMethod.Draw();
            base.Draw(gameTime);
        }



    }
}
