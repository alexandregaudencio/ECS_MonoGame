using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Components.Cam;

namespace ECS.Primitives
{
    internal class RightTriangle : Shape
    {
        public RightTriangle(Game game, ICamPerspective iCameraProperties) : base(game, iCameraProperties)
        {
            Transform.Scale = Vector3.One *10;
            Transform.Translate(Vector3.Up);
            Color = Color.Gold;

            SetVertexBuffer();
            SetIndexBuffer();

            //GraphicsDevice.RasterizerState = new RasterizerState()
            //{
            //    CullMode = CullMode.None,
            //};
        }

        protected override void SetVertexBuffer()
        {
            verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0*Transform.Scale.X, 0,  0*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0, 0.5f*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0, -0.5f*Transform.Scale.Z), Color),
            };

            vertexBuffer = new VertexBuffer(GraphicsDevice,typeof(VertexPositionColor), verts.Length,BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(verts);
        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indexData.Length, BufferUsage.None);
            indexBuffer.SetData<short>(indexData);

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
