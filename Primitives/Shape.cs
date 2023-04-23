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
    public abstract class Shape : EntityBase
    {

        protected VertexPositionColor[] verts;
        protected VertexBuffer vertexBuffer;

        protected BasicEffect basicEffect;

        protected short[] indexData;
        protected IndexBuffer indexBuffer;

        public Color Color { get; set; } = Color.Gray;

        BoundingBox boundingBox;

        bool wireframe = true;

        private ICamPerspective iCameraProperties;

        public Shape(Game game, ICamPerspective iCameraProperties) : base(game)
        {
            Transform = new Transform();
            this.iCameraProperties = iCameraProperties;
            basicEffect = new BasicEffect(GraphicsDevice);

            //GraphicsDevice.RasterizerState = new RasterizerState()
            //{
            //    CullMode = CullMode.None,
            //};


        }

        protected abstract void SetVertexBuffer();
        protected abstract void SetIndexBuffer();

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Game.GraphicsDevice.Indices = indexBuffer;
            basicEffect.World = Transform.Matrix;
            basicEffect.View = iCameraProperties.View;
            basicEffect.Projection = iCameraProperties.Projection;
            basicEffect.VertexColorEnabled = true;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                    verts, 0, verts.Length, indexData, 0, indexData.Length /3 );
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





    }
}
