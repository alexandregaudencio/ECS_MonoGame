using ECS.Core.Components;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    public abstract class Shape : Entity
    {

        protected VertexPositionColorTexture[] vertsTexture;
        protected VertexBuffer vertexBuffer;
        protected BasicEffect basicEffect;
        protected short[] indexData;
        protected IndexBuffer indexBuffer;
        public Color Color { get; set; } = Color.Gray;
        protected Texture2D texture;
        protected string texturePath = "";
        private readonly ICameraPerspective iCameraProperties;
        public PrimitiveType PrimitiveType { get; private set; } = PrimitiveType.TriangleList;

        public Shape(Game game, ICameraPerspective iCameraProperties, Color color, string texturePath) : base(game)
        {
            Transform = new Transform(game);
            this.iCameraProperties = iCameraProperties;
            this.texturePath = texturePath;
            SetColor(color);

        }

        protected override void LoadContent()
        {


            base.LoadContent();
        }


        public override void Initialize()
        {
            basicEffect = new BasicEffect(Game.GraphicsDevice);

            SetVertexTexture();
            SetIndexBuffer();
            SetVertexBuffer();

            Game.GraphicsDevice.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None,
            };
            base.Initialize();
        }

        protected abstract void SetVertexTexture();
        protected abstract void SetIndexBuffer();

        private void SetVertexBuffer()
        {
            vertexBuffer = new VertexBuffer(GraphicsDevice,
                         typeof(VertexPositionColorTexture),
                         vertsTexture.Length,
                         BufferUsage.WriteOnly);

            vertexBuffer.SetData(vertsTexture);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Game.GraphicsDevice.Indices = indexBuffer;

            basicEffect.World = Transform.World;
            basicEffect.View = iCameraProperties.View;
            basicEffect.Projection = iCameraProperties.Projection;
            basicEffect.Texture = texture;
            basicEffect.TextureEnabled = true;
            basicEffect.VertexColorEnabled = true;
            //basicEffect.FogEnabled = true;
            //basicEffect.FogColor = 
            //basicEffect.EnableDefaultLighting();
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColorTexture>(PrimitiveType,
                 vertsTexture, 0, vertsTexture.Length, indexData, 0, indexData.Length / 3);

            }

            base.Draw(gameTime);

        }

        public void SetColor(Color color)
        {
            Color = color;
            if (vertsTexture == null) return;
            for (int i = 0; i < vertsTexture?.Length; i++)
            {
                vertsTexture[i].Color = Color;
            }
        }

        public void SetPrimitiveType(PrimitiveType type)
        {
            PrimitiveType = type;
            SetFillMode(FillMode.WireFrame);

        }



        public void SetFillMode(FillMode fillMode)
        {
            RasterizerState rs = new RasterizerState
            {
                CullMode = CullMode.None,
                FillMode = fillMode
            };

            GraphicsDevice.RasterizerState = rs;
        }




    }
}
