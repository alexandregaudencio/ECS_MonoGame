using ECS.Core.Components.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    public class Quad : ShapeRenderMethod
    {
        public Quad(Color color, string texturePath = "") : base(color, texturePath)
        {

        }


        public override void SetIndexData()
        {
            indexData = new short[]
            {
                    0, 1, 2,
                    0, 2, 3,
            };
        }

        public override void SetVertexTextureData()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {

                    new VertexPositionColorTexture(new Vector3( 1, 0, 1), Color,new Vector2(1,1)),
                    new VertexPositionColorTexture(new Vector3( 1, 0,-1), Color,new Vector2(1,0)),
                    new VertexPositionColorTexture(new Vector3(-1, 0,-1), Color,new Vector2(0,0)),
                    new VertexPositionColorTexture(new Vector3(-1, 0, 1), Color,new Vector2(0,1)),
            };

        }



    }
}
