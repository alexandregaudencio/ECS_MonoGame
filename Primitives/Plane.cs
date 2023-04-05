using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Primitives
{
    public class Plane : DrawableGameComponent
    {
        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;
        Matrix world;
        Matrix view;
        Matrix projection;
        BasicEffect basicEffect;

        public Vector3 Position { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }


        public Plane(Game game, Vector3 position, float scale,  Color color) : base(game)
        {
            Position = position;
            Scale = scale;
            Color = color;

        }

        public override void Initialize()
        {
            base.Initialize();

            world = Matrix.Identity;
            view = Matrix.CreateLookAt(new Vector3(5, 5, 5), Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height, 1, 100);


            verts = new VertexPositionColor[6];
            verts[0] = new VertexPositionColor(new Vector3(Position.X -1 * Scale, Position.Y -0 , Position.Z -1 * Scale), Color);
            verts[1] = new VertexPositionColor(new Vector3(Position.X +1 * Scale, Position.Y -0 , Position.Z -1 * Scale), Color);
            verts[2] = new VertexPositionColor(new Vector3(Position.X +1 * Scale, Position.Y -0 , Position.Z +1 * Scale), Color);
            verts[3] = new VertexPositionColor(new Vector3(Position.X -1 * Scale, Position.Y - 0 , Position.Z -1 * Scale), Color);
            verts[4] = new VertexPositionColor(new Vector3(Position.X +1 * Scale, Position.Y - 0 , Position.Z +1 * Scale), Color);
            verts[5] = new VertexPositionColor(new Vector3(Position.X -1 * Scale, Position.Y - 0 , Position.Z +1 * Scale), Color);

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

            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
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
