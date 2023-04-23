using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Components.Cam;
using System.Transactions;
using ECS.Components;

namespace ECS.Primitives
{
    public class Plane : DrawableGameComponent
    {
        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;
        BasicEffect basicEffect;
        readonly ICamPerspective cameraProperties;
        Transform transform;

        public Vector3 Position { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }



        public Plane(Game game, Vector3 position, ICamPerspective cameraProperties) : base(game)
        {
            transform = new Transform(position);

            this.cameraProperties = cameraProperties;
            Position = position;
            Scale = 5;

        }

        public override void Initialize()
        {
            base.Initialize();

            verts = new VertexPositionColor[6];
            verts[0] = new VertexPositionColor(new Vector3( - 1 * Scale,  - 1,  - 1 * Scale), Color);
            verts[1] = new VertexPositionColor(new Vector3( + 1 * Scale,  - 1,  - 1 * Scale), Color);
            verts[2] = new VertexPositionColor(new Vector3(+ 1 * Scale,  - 1,  + 1 * Scale), Color);
            verts[3] = new VertexPositionColor(new Vector3( - 1 * Scale, - 1,  - 1 * Scale), Color);
            verts[4] = new VertexPositionColor(new Vector3( + 1 * Scale,  - 1,  + 1 * Scale), Color);
            verts[5] = new VertexPositionColor(new Vector3( - 1 * Scale, - 1,  + 1 * Scale), Color);

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData(verts);

            basicEffect = new BasicEffect(GraphicsDevice);

            //RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            //GraphicsDevice.RasterizerState = rs;
        }


        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            basicEffect.World = /*cameraProperties.World;*/ transform.Matrix;
            basicEffect.View = cameraProperties.View;
            basicEffect.Projection = cameraProperties.Projection;
            basicEffect.VertexColorEnabled = true;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, verts, 0, 2);

            }
            base.Draw(gameTime);
        }


    }
}
