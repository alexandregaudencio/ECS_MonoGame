using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    class HeightMapGrid : HeightMapRenderMethod
    {


        public HeightMapGrid(Vector2 size, string texturePath = "", string heightMapPath = "", string effectPath = "")
            : base(texturePath, heightMapPath, effectPath)
        {
            this.Size = size;
        }

        public override void SetVertexTextureData()
        {
            this.vertsTexture = new VertexPositionNormalTexture[Row * Col];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    float u = (float)j / (Col - 1);
                    float v = (float)i / (Row - 1);

                    int _u = (int)((heightMap.Width - 1) * u);
                    int _v = (int)((heightMap.Height - 1) * v);

                    Color c = heightMapColorData[_v * heightMap.Width + _u];

                    this.vertsTexture[i * Col + j] =
                        new VertexPositionNormalTexture(
                            new Vector3(j - ((Col - 1f) / 2f), c.B / 20f, i - ((Row - 1f) / 2f)),
                            new Vector3(0, 1, 0),
                            new Vector2(u, v));
                }
            }
        }

        public override void SetIndexData()
        {
            this.indexData = new short[(Row - 1) * (Col - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < Row - 1; i++)
            {
                for (int j = 0; j < Col - 1; j++)
                {
                    indexData[k++] = (short)(i * Col + j);
                    indexData[k++] = (short)(i * Col + (j + 1));
                    indexData[k++] = (short)((i + 1) * Col + j);

                    indexData[k++] = (short)(i * Col + (j + 1));
                    indexData[k++] = (short)((i + 1) * Col + (j + 1));
                    indexData[k++] = (short)((i + 1) * Col + j);
                }
            }
        }




    }
}
