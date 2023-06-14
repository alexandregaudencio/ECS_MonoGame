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

        public Texture2D heightMap { get; protected set; }
        public Texture2D texture { get; protected set; }

        private string heightMapPath = "";
        protected string texturePath = "";
        protected string effectPath = "";
        protected int primitiveCount = 3;

        protected Color[] heightMapColorData;

        bool normalsVisible = false;
        public override void SetNormalsVisible(bool value) { normalsVisible = value; }
        VertexPositionColor[] normals;
        VertexBuffer nBuffer;
        protected BasicEffect normalsEffect;

        VertexBufferBinding[] vbb;


        protected Vector2 Size { get; set; }
        public int Row { get { return (int)Size.X; } }
        public int Col { get { return (int)Size.Y; } }

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


        public void SetVertexNormalbuffer()
        {
            int n = 0;
            for (int i = 0; i < vertsTexture.Length; i++)
            {
                this.normals[n++] = new VertexPositionColor(vertsTexture[i].Position, Color.Green);
                this.normals[n++] = new VertexPositionColor(vertsTexture[i].Position + vertsTexture[i].Normal, Color.YellowGreen);
            }

            nBuffer = new VertexBuffer(Renderer.Game.GraphicsDevice,
                                typeof(VertexPositionColor),
                                this.normals.Length,
                                BufferUsage.None);
            this.nBuffer.SetData<VertexPositionColor>(this.normals);


            this.vbb = new VertexBufferBinding[]
            {
                this.vertexBuffer,
                this.nBuffer,
            }; 
        }

        public void RecalculateNormals()
        {
            int k = 0;
            for (int i = 0; i < Row - 1; i++)
            {
                for (int j = 0; j < Col - 1; j++)
                {
                    for (int l = 0; l < 2; l++)
                    {
                        Vector3 v1 = vertsTexture[indexData[k++]].Position - vertsTexture[indexData[k]].Position;
                        Vector3 v2 = vertsTexture[indexData[k++]].Position - vertsTexture[indexData[k++]].Position;

                        Vector3 vr = Vector3.Cross(v2, v1);

                        k -= 3;

                        vertsTexture[indexData[k++]].Normal += vr;
                        vertsTexture[indexData[k++]].Normal += vr;
                        vertsTexture[indexData[k++]].Normal += vr;
                    }
                }
            }


            for (int i = 0; i < this.vertsTexture.Length; i++)
            {
                this.vertsTexture[i].Normal.Normalize();
            }

        }


        public override void Initialize()
        {
            normalsEffect = new BasicEffect(Renderer.Game.GraphicsDevice);

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


            normals = new VertexPositionColor[vertsTexture.Length * 2];
            RecalculateNormals();
            SetVertexNormalbuffer();




            base.Initialize();
        }



        public override void Draw()
        {
            //Renderer.Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Renderer.Game.GraphicsDevice.SetVertexBuffers(vbb);
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





            #region normal visualization
            if (normalsVisible)
            {
                normalsEffect.World = Renderer.Transform.World;
                normalsEffect.View = Renderer.icameraPerspective.View;
                normalsEffect.Projection = Renderer.icameraPerspective.Projection;
                normalsEffect.VertexColorEnabled = true;

                foreach (EffectPass pass in normalsEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();

                    Renderer.Game.GraphicsDevice.DrawUserPrimitives
                        <VertexPositionColor>(PrimitiveType.LineList,
                                              this.normals,
                                              0,
                                              this.normals.Length / 2);
                }
            }
           
            #endregion


            base.Draw();
        }

    }
}
