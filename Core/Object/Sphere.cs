using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;

namespace ECS.Core.Object
{
    public class Sphere : GameObject
    {

        public Sphere(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            ModelRenderer = new Components.Renderer.ModelRenderer(game, cameraPerspective, Transform, "sphere");
        }
    }
}
