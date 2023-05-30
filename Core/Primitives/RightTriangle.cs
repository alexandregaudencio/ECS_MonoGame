using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    internal class RightTriangle : Shape
    {
        public RightTriangle(Game game, ICamPerspective iCameraProperties, Color color = default, string texturePath = "") : base(game, iCameraProperties, color)
        {
            this.texturePath = texturePath;
            this.Color = color;
        }

        public override void Initialize()
        {
            Game.GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
            };

            base.Initialize();
        }

        protected override void SetVertexTexture()
        {
            vertsTexture = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3( 0, 0,     0), Color, new Vector2(0.5f,0.5f)),
                new VertexPositionColorTexture(new Vector3( 1, 0,  0.5f), Color, new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3( 1, 0, -0.5f), Color, new Vector2(1,0)),
            };

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
