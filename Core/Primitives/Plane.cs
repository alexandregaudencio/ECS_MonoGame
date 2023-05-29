using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    public class Plane : Shape
    {

        public Plane(Game game, ICamPerspective iCameraProperties) : base(game, iCameraProperties)
        {
            Color = Color.Black;
            Transform.SetScale(Vector3.One * 10);
            SetVertexBuffer();
            SetIndexBuffer();
            SetFillMode(FillMode.Solid);

            Game.GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
            };
        }


        protected override void SetVertexBuffer()
        {
            verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0, 1*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0,-1*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X, 0,-1*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X, 0, 1*Transform.Scale.Z), Color),
            };

            vertexBuffer = new VertexBuffer(GraphicsDevice,
                                     typeof(VertexPositionColor),
                                     verts.Length,
                                     BufferUsage.None);

            vertexBuffer.SetData(verts);

        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2,
                0, 2, 3,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indexData.Length, BufferUsage.None);
            indexBuffer.SetData(indexData);

        }





    }
}
