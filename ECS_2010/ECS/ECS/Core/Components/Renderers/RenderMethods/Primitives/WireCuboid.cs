using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    class WireCuboid : ShapeRenderMethod
    {

        public WireCuboid(Color color, string texturePath = "")
            : base(color, texturePath)
        {
        }

        public override void SetVertexTextureData()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {
                // Front face
                new VertexPositionColorTexture(new Vector3(-1, -1, 1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(1, -1, 1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(1, 1, 1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(-1, 1, 1), Color.White, Vector2.Zero),

                // Back face
                new VertexPositionColorTexture(new Vector3(-1, -1, -1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(1, -1, -1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(1, 1, -1), Color.White, Vector2.Zero),
                new VertexPositionColorTexture(new Vector3(-1, 1, -1), Color.White, Vector2.Zero),
            };
        }

        public override void SetIndexData()
        {
            indexData = new short[]
            {
                // Front face
                0, 1,
                1, 2,
                2, 3,
                3, 0,

                // Back face
                4, 5,
                5, 6,
                6, 7,
                7, 4,

                // Connecting edges
                0, 4,
                1, 5,
                2, 6,
                3, 7,
            };
        }

    }

}
