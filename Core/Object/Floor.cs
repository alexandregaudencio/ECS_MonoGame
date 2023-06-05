using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using Microsoft.Xna.Framework;

namespace ECS.Core.Object
{
    internal class Floor : GameObject
    {
        public Floor(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Quad(Color.Brown));
            Collider.SetActive(false);

        }

        public override void Initialize()
        {

            base.Initialize();
        }


    }
}
