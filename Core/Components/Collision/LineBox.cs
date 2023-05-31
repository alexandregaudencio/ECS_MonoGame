using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework.Input;

namespace ECS.Core.Components.Collision
{
    public class LineBox : DrawableGameComponent
    {
        Transform transform;
        VertexPositionColor[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        private BasicEffect effect;
        private ICameraPerspective iCameraPerspective;
        Color color = Color.Black;

        public LineBox(Game game, ICameraPerspective iCameraPerspective, Transform transform) : base(game)
        {

            this.iCameraPerspective = iCameraPerspective;
            this.transform = transform;


        }

        public override void Initialize()
        {
            effect = new BasicEffect(Game.GraphicsDevice);

            this.CreateVertex();
            this.CreateIndexes();
            this.CreateVBuffer();
            this.CreateIBuffer();
            base.Initialize();
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
        }


        private void CreateVertex()
        {
            float v = 1f;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-v, v,-v), this.color),//0
                new VertexPositionColor(new Vector3( v, v,-v), this.color),//1
                new VertexPositionColor(new Vector3(-v, v, v), this.color),//2
                new VertexPositionColor(new Vector3( v, v, v), this.color),//3

                new VertexPositionColor(new Vector3(-v,-v,-v), this.color),//4
                new VertexPositionColor(new Vector3( v,-v,-v), this.color),//5
                new VertexPositionColor(new Vector3(-v,-v, v), this.color),//6
                new VertexPositionColor(new Vector3( v,-v, v), this.color),//7
            };
        }

        private void CreateVBuffer()
        {
            this.vBuffer = new VertexBuffer(Game.GraphicsDevice,
                                            typeof(VertexPositionColor),
                                            this.verts.Length,
                                            BufferUsage.None);
            this.vBuffer.SetData<VertexPositionColor>(this.verts);
        }

        private void CreateIndexes()
        {
            this.indexes = new short[]
            {
                // cima
                0, 1,
                1, 3,
                3, 2,
                2, 0,

                // baixo
                4, 5,
                5, 7,
                7, 6,
                6, 4,

                // vertical
                0, 4,
                1, 5,
                2, 6,
                3, 7
            };
        }

        private void CreateIBuffer()
        {
            this.iBuffer = new IndexBuffer(Game.GraphicsDevice,
                                           IndexElementSize.SixteenBits,
                                           this.indexes.Length,
                                           BufferUsage.None);
            this.iBuffer.SetData<short>(this.indexes);
        }

        public override void Draw(GameTime gameTime)
        {
            effect.World = transform.Matrix;
            effect.View = iCameraPerspective.View;
            effect.Projection = iCameraPerspective.Projection;
           effect.VertexColorEnabled = true;

            Game.GraphicsDevice.SetVertexBuffer(vBuffer);
            Game.GraphicsDevice.Indices = iBuffer;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionColor>(PrimitiveType.LineList,
                                          verts,
                                          0,
                                          verts.Length,
                                          indexes,
                                          0,
                                          indexes.Length / 2);
            }

            effect.VertexColorEnabled = false;
        }



        public override void Update(GameTime gameTime)
        {
            //ProcessInputCommands();
            base.Update(gameTime);
        }


        public void SetColor(Color color)
        {
            this.color = color;

            for (int i = 0; i < verts.Length; i++)
            {
                verts[i].Color = this.color;
            }
        }


        //private void ProcessInputCommands()
        //{
        //    float speed = 5000;
        //    if (Keyboard.GetState().IsKeyDown(Keys.A))
        //    {
        //        transform.Translate(-Vector3.UnitX * speed);
        //    }
        //    if (Keyboard.GetState().IsKeyDown(Keys.D))
        //    {
        //        this.transform.Translate(Vector3.UnitX * speed);
        //    }
        //    if (Keyboard.GetState().IsKeyDown(Keys.W))
        //    {
        //        this.transform.Translate(Vector3.UnitZ * speed);
        //    }
        //    if (Keyboard.GetState().IsKeyDown(Keys.S))
        //    {
        //        this.transform.Translate(-Vector3.UnitZ * speed);
        //    }


        //}


    }

}
