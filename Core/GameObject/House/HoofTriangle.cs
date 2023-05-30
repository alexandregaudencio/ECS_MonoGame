
using ECS.Core.Components.Cam;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.BaseObject.House
{
    internal class HoofTriangle : Shape
    {
        public HoofTriangle(Game game, ICameraPerspective iCameraProperties, Color color, string texturePath) : base(game, iCameraProperties, color, texturePath)
        {
        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indexData.Length, BufferUsage.None);
            indexBuffer.SetData(indexData);

        }

        protected override void SetVertexTexture()
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
