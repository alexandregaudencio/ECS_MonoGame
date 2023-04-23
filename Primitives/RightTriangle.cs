//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECS.Primitives
//{
//    internal class RightTriangle : DrawableGameComponent
//    {
//        VertexPositionColor[] verts;
//        VertexBuffer vertexBuffer;
//        Matrix world;
//        Matrix view;
//        Matrix projection;
//        BasicEffect basicEffect;


//        public Vector3 Position { get; set; }
//        public float Scale { get; set; }
//        public Color Color { get; set; }


//        public RightTriangle(Game game, Vector3 position,float scale, Color color)
//            : base(game)
//        {
//            Position = position;
//            Scale = scale;
//            Color = color;

//        }

//        public override void Initialize()
//        {
//            base.Initialize();

//            world = Matrix.Identity;
//            view = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
//            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height, 1, 100);

//            //GraphicsDevice.RasterizerState = RasterizerState.CullNone; //(permite ver o plano de costas também)
//            verts = new VertexPositionColor[3];
//            verts[0] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
//            verts[1] = new VertexPositionColor(new Vector3(Position.X + 1 * Scale, Position.Y + 1 * Scale, Position.Z + 1 * Scale), Color);
//            verts[2] = new VertexPositionColor(new Vector3(Position.X - 1 * Scale, Position.Y -1 * Scale, Position.Z + 1 * Scale), Color);

//            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
//            vertexBuffer.SetData<VertexPositionColor>(verts);

//            basicEffect = new BasicEffect(GraphicsDevice);


//        }


//        public override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.SetVertexBuffer(vertexBuffer);

//            basicEffect.World = world;
//            basicEffect.View = this.view;
//            basicEffect.Projection = this.projection;
//            basicEffect.VertexColorEnabled = true;

//            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
//            {
//                pass.Apply();
//                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, verts, 0, 1);

//            }
//            base.Draw(gameTime);
//        }

//    }
//}
