using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Components.Cam;
using System.Transactions;
using ECS.Components;

namespace ECS.Primitives
{
    public class Plane : Shape
    {
        public Plane(Game game, ICamPerspective iCameraProperties) : base(game, iCameraProperties)
        {
            Color = Color.Black;
            Transform.Scale = Vector3.One*5;
            SetVertexBuffer();
            SetIndexBuffer();
            SetFillMode(FillMode.Solid);

            GraphicsDevice.RasterizerState = new RasterizerState()
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

            vertexBuffer.SetData<VertexPositionColor>(verts);

        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2, 
                0, 2, 3,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice,
                                               IndexElementSize.SixteenBits,
                                               indexData.Length,
                                               BufferUsage.None);

            indexBuffer.SetData<short>(indexData);

        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }




    }
}
