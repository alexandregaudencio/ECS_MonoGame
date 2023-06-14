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
        private Vector2 size;
        private int row { get { return (int)size.X; } }
        private int col { get { return (int)size.Y; } }

        public HeightMapGrid(Vector2 size, string texturePath = "", string heightMapPath = "", string effectPath = "")
            : base(texturePath, heightMapPath, effectPath)
        {
            this.size = size;
        }

        public override void SetVertexTextureData()
        {
            this.vertsTexture = new VertexPositionNormalTexture[row * col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    float u = (float)j / (col - 1);
                    float v = (float)i / (row - 1);

                    int _u = (int)((heightMap.Width - 1) * u);
                    int _v = (int)((heightMap.Height - 1) * v);

                    Color c = heightMapColorData[_v * heightMap.Width + _u];

                    this.vertsTexture[i * col + j] =
                        new VertexPositionNormalTexture(
                            new Vector3(j - ((col - 1f) / 2f), c.B / 20f, i - ((row - 1f) / 2f)),
                            new Vector3(0, 1, 0),
                            new Vector2(u, v));
                }
            }
        }

        public override void SetIndexData()
        {
            this.indexData = new short[(row - 1) * (col - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    indexData[k++] = (short)(i * col + j);
                    indexData[k++] = (short)(i * col + (j + 1));
                    indexData[k++] = (short)((i + 1) * col + j);

                    indexData[k++] = (short)(i * col + (j + 1));
                    indexData[k++] = (short)((i + 1) * col + (j + 1));
                    indexData[k++] = (short)((i + 1) * col + j);
                }
            }
        }





    }
}
