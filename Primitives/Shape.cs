using ECS.BaseObject;
using ECS.Components;
using ECS.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Primitives
{
    public class Shape : EntityBase
    {

        protected VertexPositionColor[] verts;
        protected VertexBuffer vertexBuffer;

        protected BasicEffect basicEffect;

        protected short[] index;
        protected IndexBuffer indexBuffer;

        //protected Matrix world;
        //protected Vector3 position;

        protected float angle;

        BoundingBox boundingBox;

        bool wireframe = true;

        protected ICamPerspective iCameraProperties;

        public Shape(Game game, Vector3 position, ICamPerspective iCameraProperties) : base(game)
        {
            
            this.iCameraProperties = iCameraProperties;
            basicEffect = new BasicEffect(GraphicsDevice);
            this.transform = new Transform(position);


            //world = Matrix.Identity;



            //this.position = position;

            this.angle = 0;



        }

        protected virtual void SetVertexBuffer()
        {

        }

        protected virtual void SetIndexBuffer()
        {

        }

        public override void Initialize()
        {
            SetVertexBuffer();
            SetIndexBuffer();
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Game.GraphicsDevice.Indices = indexBuffer;
            basicEffect.World = transform.Matrix;
            basicEffect.View = iCameraProperties.View;
            basicEffect.Projection = iCameraProperties.Projection;
            basicEffect.VertexColorEnabled = true;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                    verts, 0, verts.Length, index, 0, index.Length / 3);
            }

            base.Draw(gameTime);

        }

        public void SetFillMode(FillMode fillMode)
        {
            RasterizerState rs = new RasterizerState 
            { 

                FillMode = fillMode
            };

            GraphicsDevice.RasterizerState = rs;


        }

        public override void Update(GameTime gameTime)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    fillMode = FillMode.Solid;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    fillMode = FillMode.WireFrame;
            //        }
            base.Update(gameTime);
        }


    }
}
