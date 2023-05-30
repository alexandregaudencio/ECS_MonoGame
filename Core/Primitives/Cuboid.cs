using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    public class Cuboid : Shape
    {

        public Cuboid(Game game, ICamPerspective iCamPerspective, Color color, string texturePath = "") : base(game, iCamPerspective, color, texturePath)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void SetVertexTexture()
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

        protected override void SetIndexBuffer()
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

            indexBuffer = new IndexBuffer(GraphicsDevice,
                                               IndexElementSize.SixteenBits,
                                               indexData.Length,
                                               BufferUsage.None);

            indexBuffer.SetData(indexData);

        }



    }
}
