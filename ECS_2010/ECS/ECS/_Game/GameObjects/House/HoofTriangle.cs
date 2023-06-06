using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS._Game.GameObjects.House
{
    internal class HoofTriangle : ShapeRenderMethod
    {
        public HoofTriangle(Color color, string texturePath) : base(color)
        {

        }

        public override void SetIndexData()
        {
            indexData = new short[]
            {
                0, 1, 2,
            };
        }

        public override void SetVertexTextureData()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3( 0, 1,   0), Color, new Vector2(0.5f,0.5f)),
                new VertexPositionColorTexture(new Vector3( 1, 0,  1), Color, new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3( 1, 0, -1), Color, new Vector2(1,0)),
            };
        }



    }
}
