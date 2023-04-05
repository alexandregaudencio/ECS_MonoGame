using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Primitives
{
    public class Cuboid : DrawableGameComponent
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


        public Cuboid(Game game, Vector3 position, float scale, Color color) : base(game)
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

            verts = new VertexPositionColor[36];
            verts[0] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[1] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[2] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[3] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[4] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[5] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);

            verts[6] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[7] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[8] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[9] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[10] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[11] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);

            verts[12] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color) ;
            verts[13] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[14] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[15] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[16] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[17] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);

            verts[18] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[19] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[20] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[21] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[22] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[23] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);

            verts[24] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[25] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[26] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[27] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y - 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[28] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[29] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);

            verts[30] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[31] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[32] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[33] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
            verts[34] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);
            verts[35] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z - 1 * Scale), Color);



            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData(verts);

            basicEffect = new BasicEffect(GraphicsDevice);


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
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, verts, 0, 12);

            }
            base.Draw(gameTime);
        }

        

    }
}
