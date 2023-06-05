using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers.Primivites
{
    public class Cuboid : ShapeRenderMethod
    {
        public Cuboid(Color color, string texturePath = "") : base(color, texturePath)
        {

        }

        public override void SetVertexTextureData()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(-1, 1, 1), Color, new Vector2(1,0)), // 0
                new VertexPositionColorTexture(new Vector3( 1, 1, 1), Color, new Vector2(0,0)), // 1
                new VertexPositionColorTexture(new Vector3( 1,-1, 1), Color, new Vector2(0,1)), // 2
                new VertexPositionColorTexture(new Vector3(-1,-1, 1), Color, new Vector2(1,1)), // 3
                new VertexPositionColorTexture(new Vector3(-1, 1,-1), Color, new Vector2(0,1)), // 4
                new VertexPositionColorTexture(new Vector3( 1, 1,-1), Color, new Vector2(1,1)), // 5
                new VertexPositionColorTexture(new Vector3( 1,-1,-1), Color, new Vector2(1,0)), // 6
                new VertexPositionColorTexture(new Vector3(-1,-1,-1), Color, new Vector2(1,1)) // 7
            };
        }

        public override void SetIndexData()
        {
            indexData = new short[]
            {
                0, 1, 2, // front
                0, 2, 3,
                1, 5, 6, // rigth
                1, 6, 2,
                5, 4, 7, // back
                5, 7, 6,
                4, 0, 3, // left
                4, 3, 7,
                4, 5, 1, // up
                4, 1, 0,
                3, 2, 6, // down
                3, 6, 7,
            };
        }


    }
}
