using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;

namespace ECS.Core.Components.Renderers
{
    public class Renderer : Entity, IActivable
    {
        public RenderMethod RenderMethod { get; private set; }
        public readonly ICameraPerspective icameraPerspective;

        public bool Active { get; private set; } = true;
        public void SetActive(bool active) => Active = active;

        public Renderer(Game game, ICameraPerspective icameraPerspective, RenderMethod renderMethod) : base(game)
        {
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
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            RenderMethod.Draw();
            base.Draw(gameTime);
        }



    }
}
