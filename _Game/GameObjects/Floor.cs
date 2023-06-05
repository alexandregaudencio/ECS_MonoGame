using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects
{
    internal class Floor : GameObject
    {
        public Floor(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Quad(Color.Brown));
            Collider.SetActive(false);
            Renderer.SetActive(true);

        }

        public override void Initialize()
        {

            base.Initialize();
        }


    }
}
