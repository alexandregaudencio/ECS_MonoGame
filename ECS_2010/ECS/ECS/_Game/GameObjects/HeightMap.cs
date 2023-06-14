using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ECS.Core.Entities;
using ECS.Core.Components.Cam;

namespace ECS
{
    public class HeightMap : Entity
    {
        VertexPositionNormalTexture[] verts;
        VertexBuffer vBuffer;
        short[] index;
        IndexBuffer iBuffer;
        Texture2D heightMap, texture;
        BasicEffect effect;

        private ICameraPerspective iCameraPerspective;

        int row, col;

        public HeightMap(Game game, ICameraPerspective iCameraPerspective) : base (game)
        {
            this.iCameraPerspective = iCameraPerspective;

            this.row = 100;
            this.col = 100;


            Transform.Translate(Vector3.UnitY * -10);
        }


        public override void Initialize()
        {
            this.heightMap = Game.Content.Load<Texture2D>(@"Textures\HeightMap\mountain1");

            Color[] color = new Color[heightMap.Width * heightMap.Height];
            this.heightMap.GetData<Color>(color);

            this.verts = new VertexPositionNormalTexture[row * col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    float u = (float)j / (col - 1);
                    float v = (float)i / (row - 1);

                    int _u = (int)((heightMap.Width - 1) * u);
                    int _v = (int)((heightMap.Height - 1) * v);

                    Color c = color[_v * heightMap.Width + _u];

                    this.verts[i * col + j] =
                        new VertexPositionNormalTexture(
                            new Vector3(j - ((col - 1f) / 2f), c.B / 20f, i - ((row - 1f) / 2f)),
                            new Vector3(0, 1, 0),
                            new Vector2(u, v));
                }
            }

            this.vBuffer = new VertexBuffer(Game.GraphicsDevice,
                                            typeof(VertexPositionNormalTexture),
                                            this.verts.Length,
                                            BufferUsage.None);
            this.vBuffer.SetData<VertexPositionNormalTexture>(this.verts);

            this.index = new short[(row - 1) * (col - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    index[k++] = (short)(i * col + j);
                    index[k++] = (short)(i * col + (j + 1));
                    index[k++] = (short)((i + 1) * col + j);

                    index[k++] = (short)(i * col + (j + 1));
                    index[k++] = (short)((i + 1) * col + (j + 1));
                    index[k++] = (short)((i + 1) * col + j);
                }
            }

            this.iBuffer = new IndexBuffer(Game.GraphicsDevice,
                                           IndexElementSize.SixteenBits,
                                           this.index.Length,
                                           BufferUsage.None);
            this.iBuffer.SetData<short>(this.index);

            this.texture = Game.Content.Load<Texture2D>(@"Textures\sand");

            this.effect = new BasicEffect(Game.GraphicsDevice);
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            //this.Transform.RotateY(gameTime.ElapsedGameTime.Milliseconds * 0.0001f);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.SetVertexBuffer(this.vBuffer);
            Game.GraphicsDevice.Indices = this.iBuffer;

            effect.World = Transform.World;
            effect.View = iCameraPerspective.View;
            effect.Projection = iCameraPerspective.Projection;
            effect.TextureEnabled = true;
            effect.Texture = this.texture;
            effect.EnableDefaultLighting();

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionNormalTexture>(PrimitiveType.TriangleList,
                                                  this.verts,
                                                  0,
                                                  this.verts.Length,
                                                  this.index,
                                                  0,
                                                  this.index.Length / 3);
            }

        }
    }
}
