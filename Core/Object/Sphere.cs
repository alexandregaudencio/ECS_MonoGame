using ECS.Core.Components.Cam;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
