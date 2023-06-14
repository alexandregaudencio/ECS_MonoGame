using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ECS.Core.Components.Renderers
{
    public abstract class HeightMapRenderMethod : RenderMethod, IPrimitiveBuffer
    {
        protected VertexPositionNormalTexture[] vertsTexture;
        protected VertexBuffer vertexBuffer;
        protected short[] indexData;
        protected IndexBuffer indexBuffer;

        protected Texture2D heightMap;
        protected Texture2D texture;

        private string heightMapPath = "";
        protected string texturePath = "";
        protected string effectPath = "";
        protected int primitiveCount = 3;

        protected Color[] heightMapColorData;


        public HeightMapRenderMethod(string texturePath = "", string heightMapPath = "", string effectPath = "") 
        {
            this.heightMapPath = heightMapPath;
            this.texturePath = texturePath;
            this.effectPath = effectPath;
  

        }

        public abstract void SetVertexTextureData();

        public abstract void SetIndexData();


        public void SetVertexBuffer() 
        {
            vertexBuffer = new VertexBuffer(Renderer.Game.GraphicsDevice,
             typeof(VertexPositionNormalTexture),
             vertsTexture.Length,
             BufferUsage.WriteOnly);

            vertexBuffer.SetData(vertsTexture);
        }

        public void SetIndexBuffer()
        {
            indexBuffer = new IndexBuffer(Renderer.Game.GraphicsDevice,
                                IndexElementSize.SixteenBits,
                                indexData.Length,
                                BufferUsage.None
                            );
            indexBuffer.SetData(indexData);
        }




        public override void Initialize()
        {

            //heightMap texture loading
            if (string.IsNullOrWhiteSpace(heightMapPath))
            {
                heightMap = Renderer.Game.Content.Load<Texture2D>(@"Textures\HeightMap\default");
            }
            else
            {
                heightMap = Renderer.Game.Content.Load<Texture2D>(string.Concat(@"Textures\HeightMap\", heightMapPath));
            }

            heightMapColorData = new Color[heightMap.Width * heightMap.Height];
            heightMap.GetData<Color>(heightMapColorData);





            //Color Texture  loading
            if (string.IsNullOrWhiteSpace(texturePath)) 
            {
                texture = Renderer.Game.Content.Load<Texture2D>(@"Textures\default");
            } 
            else {
                texture = Renderer.Game.Content.Load<Texture2D>(string.Concat(@"Textures\",texturePath));
            }




            //Effect loading
            if (string.IsNullOrWhiteSpace(effectPath))
            {
                effect = Renderer.Game.Content.Load<Effect>(@"Effects\default");
            }
            else
            {
                effect = Renderer.Game.Content.Load<Effect>(string.Concat(@"Effects\", effectPath));
            }



            SetVertexTextureData();
            SetVertexBuffer();
            SetIndexData();
            SetIndexBuffer();



            base.Initialize();
        }



        public override void Draw()
        {
            Renderer.Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Renderer.Game.GraphicsDevice.Indices = indexBuffer;

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(Renderer.Transform.World);
            effect.Parameters["View"].SetValue(Renderer.icameraPerspective.View);
            effect.Parameters["Projection"].SetValue(Renderer.icameraPerspective.Projection);
            effect.Parameters["colorTexture"].SetValue(this.texture);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
            }


            Renderer.Game.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType,
             vertsTexture, 0, vertsTexture.Length, indexData, 0, indexData.Length / primitiveCount);
            base.Draw();
        }

    }
}
