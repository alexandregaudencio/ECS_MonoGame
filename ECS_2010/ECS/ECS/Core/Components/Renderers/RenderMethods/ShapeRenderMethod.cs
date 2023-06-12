using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{

    /// <summary>
    /// A render method abstract for primitives shapes
    /// </summary>
    public abstract class ShapeRenderMethod : RenderMethod, IPrimitiveBuffer
    {
        protected VertexPositionColorTexture[] vertsTexture;
        protected VertexBuffer vertexBuffer;
        //protected BasicEffect basicEffect;
        protected Effect effect;
        protected short[] indexData;
        protected IndexBuffer indexBuffer;
        public Color Color { get; set; }
        protected Texture2D texture;
        protected string texturePath = "";
        protected string effectPath = "";


        public ShapeRenderMethod(Color color, string texturePath = "")
        {
            Color = color;
            this.texturePath = texturePath;
        }

        public ShapeRenderMethod(Color color, string texturePath = "", string effectPath = "")
        {
            Color = color;
            this.texturePath = texturePath;
            this.effectPath = effectPath;
        }


        public abstract void SetVertexTextureData();

        public abstract void SetIndexData();

        public void SetIndexBuffer()
        {
            indexBuffer = new IndexBuffer(Renderer.Game.GraphicsDevice,
                                IndexElementSize.SixteenBits,
                                indexData.Length,
                                BufferUsage.None
                            );
            indexBuffer.SetData(indexData);
        }

        public void SetVertexBuffer()
        {
            vertexBuffer = new VertexBuffer(Renderer.Game.GraphicsDevice,
             typeof(VertexPositionColorTexture),
             vertsTexture.Length,
             BufferUsage.WriteOnly);

            vertexBuffer.SetData(vertsTexture);
        }

        public override void Initialize()
        {
            //basicEffect = new BasicEffect(Renderer.Game.GraphicsDevice);

            SetVertexTextureData();
            SetIndexData();
            SetIndexBuffer();
            SetVertexBuffer();

            Renderer.Game.GraphicsDevice.RasterizerState =
                new RasterizerState()
                {
                    CullMode = CullMode.None,
                };

        }

        public override void Load()
        {
            if (string.IsNullOrEmpty(texturePath)) {
                texture = Renderer.Game.Content.Load<Texture2D>(@"Textures\default");
            } else {
                            texture = Renderer.Game.Content.Load<Texture2D>(string.Concat(@"Textures\",texturePath));
            }
            if (string.IsNullOrEmpty(effectPath))
            {
                effect = Renderer.Game.Content.Load<Effect>(@"Effects\default");
            }
            else
            {

                effect = Renderer.Game.Content.Load<Effect>(string.Concat(@"Effects\", effectPath));
            }
            

        }

        public override void Draw()
        {
            Renderer.Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Renderer.Game.GraphicsDevice.Indices = indexBuffer;

            //basicEffect.World = Renderer.Transform.World;
            //basicEffect.View = Renderer.icameraPerspective.View;
            //basicEffect.Projection = Renderer.icameraPerspective.Projection;
            //basicEffect.Texture = texture;
            //basicEffect.TextureEnabled = true;
            //basicEffect.VertexColorEnabled = true;
            ////basicEffect.FogEnabled = true;
            ////basicEffect.FogColor = 
            ////basicEffect.EnableDefaultLighting();

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(Renderer.Transform.World);
            effect.Parameters["View"].SetValue(Renderer.icameraPerspective.View);
            effect.Parameters["Projection"].SetValue(Renderer.icameraPerspective.Projection);
            effect.Parameters["colorTexture"].SetValue(this.texture);


            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Renderer.Game.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType,
                 vertsTexture, 0, vertsTexture.Length, indexData, 0, indexData.Length / 3);

            }
        }



        public override void SetColor(Color color)
        {
            Color = color;
            if (vertsTexture == null) return;
            for (int i = 0; i < vertsTexture.Length; i++)
            {
                vertsTexture[i].Color = Color;
            }
        }


    }

}
