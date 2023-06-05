using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;

namespace ECS.Core.Object
{
    public class Box : GameObject
    {
        public Box(Game game, ICameraPerspective cameraPerspective ) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Cuboid(Color.White, "madeira"));
            Collider.SetActive(true);
        }


    }

}
