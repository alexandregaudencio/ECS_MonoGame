using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    internal class RightTriangle : Shape
    {
        public RightTriangle(Game game, ICamPerspective iCameraProperties) : base(game, iCameraProperties)
        {
            Transform.SetScale(Vector3.One * 10);
            Transform.Translate(Vector3.Up);
            Color = Color.Gold;




        }

        public override void Initialize()
        {
            SetVertexBuffer();
            SetIndexBuffer();

            Game.GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
            };

            base.Initialize();
        }

        protected override void SetVertexBuffer()
        {
            verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0*Transform.Scale.X, 0,  0*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0, 0.5f*Transform.Scale.Z), Color),
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 0, -0.5f*Transform.Scale.Z), Color),
            };

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData(verts);
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

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
