using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;

using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects
{
    internal class Floor : GameObject
    {
        public Floor(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new HeightMapGrid(Vector2.One*10, "grass", "mountain1", "snow"));
            SnowController.instance.AddRenderer(Renderer);
            Collider.SetActive(false);
            Renderer.SetActive(true);

            Transform.SetScale(new Vector3(1, 0.1f, 1)*5);
            Transform.Translate(-Vector3.UnitY * 7);
            Collider.Transform.IncreaseScale(Vector3.One * 2.7f);

        }

        public override void Initialize()
        {
            Collider.SetActive(true);
            Collider.SetVisible(true);

            Transform.SetMinYOnFloor();
            base.Initialize();
        }


    }
}
