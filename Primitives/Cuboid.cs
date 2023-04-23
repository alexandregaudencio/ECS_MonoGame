using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ECS.Components.Cam;

namespace ECS.Primitives
{
    public class Cuboid : Shape 
    {

        protected Color Color { get; set; } = Color.AntiqueWhite;

        public Cuboid(Game game,ICamPerspective iCamPerspective) : base(game, iCamPerspective)
        {
            SetVertexBuffer();
            SetIndexBuffer();
        }

      
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void SetVertexBuffer()
        {
            verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X, 1*Transform.Scale.Y, 1*Transform.Scale.Z), Color.Blue), // 0
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 1*Transform.Scale.Y, 1*Transform.Scale.Z), Color.Blue), // 1
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X,-1*Transform.Scale.Y, 1*Transform.Scale.Z), Color.Brown), // 2
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X,-1*Transform.Scale.Y, 1*Transform.Scale.Z), Color.Brown), // 3
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X, 1*Transform.Scale.Y,-1*Transform.Scale.Z), Color.Yellow), // 4
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X, 1*Transform.Scale.Y,-1*Transform.Scale.Z), Color.Yellow), // 5
                new VertexPositionColor(new Vector3( 1*Transform.Scale.X,-1*Transform.Scale.Y,-1*Transform.Scale.Z), Color.Green), // 6
                new VertexPositionColor(new Vector3(-1*Transform.Scale.X,-1*Transform.Scale.Y,-1*Transform.Scale.Z), Color.Green), // 7
            };

            vertexBuffer = new VertexBuffer(GraphicsDevice,
                                     typeof(VertexPositionColor),
                                     verts.Length,
                                     BufferUsage.None);

            vertexBuffer.SetData<VertexPositionColor>(verts);

        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2, // front
                0, 2, 3,
                1, 5, 6, // rigth
                1, 6, 2,
                5, 4, 7, // back
                5, 7, 6,
                4, 0, 3, // left
                4, 3, 7,
                4, 5, 1, // up
                4, 1, 0,
                3, 2, 6, // down
                3, 6, 7,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice,
                                               IndexElementSize.SixteenBits,
                                               indexData.Length,
                                               BufferUsage.None);

            indexBuffer.SetData<short>(indexData);

        }



        #region methodo anterior



        //{
        //    VertexPositionColor[] verts;
        //    VertexBuffer vertexBuffer;
        //    BasicEffect basicEffect;
        //    Transform transform = new Transform(Vector3.Zero, Vector3.Zero, Vector3.One);

        //    //Matrix world = Matrix.Identity;
        //    public float Scale { get; set; }
        //    public Color Color { get; set; }
        //    private ICameraProperties cameraProperties;


        //    public Cuboid(Game game, ICameraProperties cameraProperties, Vector3 position, float scale, Color color) : base(game)
        //    {
        //        transform.SetPosition(position);
        //        Scale = scale;
        //        Color = color;
        //        this.cameraProperties = cameraProperties;
        //        transform.SetPosition(Vector3.One);
        //    }


        //    public override void Initialize()
        //    {
        //        base.Initialize();

        //        verts = new VertexPositionColor[36];
        //        verts[0] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[1] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[2] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[3] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[4] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[5] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);

        //        verts[6] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[7] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[8] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[9] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[10] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[11] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);

        //        verts[12] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color) ;
        //        verts[13] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[14] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[15] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[16] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[17] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);

        //        verts[18] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[19] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[20] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[21] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[22] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[23] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);

        //        verts[24] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[25] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[26] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[27] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y - 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[28] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[29] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);

        //        verts[30] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[31] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[32] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[33] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z + 1 * Scale), Color);
        //        verts[34] = new VertexPositionColor(new Vector3(transform.Position.X - 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);
        //        verts[35] = new VertexPositionColor(new Vector3(transform.Position.X + 1 * Scale, transform.Position.Y + 1 * Scale, transform.Position.Z - 1 * Scale), Color);



        //        vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
        //        vertexBuffer.SetData(verts);

        //        basicEffect = new BasicEffect(GraphicsDevice);


        //    }


        //    public override void Draw(GameTime gameTime)
        //    {
        //        GraphicsDevice.SetVertexBuffer(vertexBuffer);
        //        //GraphicsDevice.RasterizerState = RasterizerState.CullNone;
        //        basicEffect.World =  transform.Matrix;
        //        basicEffect.View = cameraProperties.View;
        //        basicEffect.Projection = cameraProperties.Projection;
        //        basicEffect.VertexColorEnabled = true;

        //        foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
        //        {
        //            pass.Apply();
        //            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, verts, 0, 12);

        //        }
        //        base.Draw(gameTime);
        //    }

        //    public override void Update(GameTime gameTime)
        //    {
        //        base.Update(gameTime);
        //        //world = Matrix.Identity;
        //        //x += 0.00001f;
        //        transform.SetRotationY(0.01f);


        //    }

        #endregion


    }
}
