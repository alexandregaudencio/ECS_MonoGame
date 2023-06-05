using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects
{
    public class Sphere : GameObject
    {

        public Sphere(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new ModelRenderMethod("sphere"));

        }

        public override void Initialize()
        {
            Collider.SetActive(true);
            Collider.SetVisible(false);

            base.Initialize();
        }




    }
}
