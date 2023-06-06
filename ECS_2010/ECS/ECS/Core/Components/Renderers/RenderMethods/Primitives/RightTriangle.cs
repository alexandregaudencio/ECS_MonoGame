using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    internal class RightTriangle : ShapeRenderMethod
    {
        public RightTriangle(Color color, string texturePath = "") : base(color, texturePath)
        {

        }

        public override void SetVertexTextureData()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3( 0, 0,     0), Color, new Vector2(0.5f,0.5f)),
                new VertexPositionColorTexture(new Vector3( 1, 0,  0.5f), Color, new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3( 1, 0, -0.5f), Color, new Vector2(1,0)),
            };
        }

        public override void SetIndexData()
        {
            indexData = new short[]
            {
                0, 1, 2,
            };
        }


    }
}
