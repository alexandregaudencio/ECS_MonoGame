using ECS.Core.Components;
using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Primitives
{
    public class Plane : Shape
    {


        //public Plane(Game game, ICamPerspective iCameraProperties) : base(game, iCameraProperties)
        //{

        //}

        //public Plane(Game game, ICamPerspective iCameraProperties, Color color) : base(game, iCameraProperties, color)
        //{
        //    SetFillMode(FillMode.Solid);
        //    Transform.SetScale(Vector3.One * 10);
        //    SetFillMode(FillMode.Solid);
        //    Color = color;
        //    //para ver  de costas também
        //    //Game.GraphicsDevice.RasterizerState = new RasterizerState()
        //    //{
        //    //    CullMode = CullMode.None,
        //    //};

        //}
        public Plane(Game game, ICamPerspective iCameraProperties, Color color, string texturePath = "") : base(game, iCameraProperties, color)
        {
            SetFillMode(FillMode.Solid);
            Transform.SetScale(Vector3.One * 10);
            SetFillMode(FillMode.Solid);
            Color = color;
            this.texturePath = texturePath;
            //para ver  de costas também
            //Game.GraphicsDevice.RasterizerState = new RasterizerState()
            //{
            //    CullMode = CullMode.None,
            //};

        }

        protected override void SetVertexTexture()
        {

            vertsTexture = new VertexPositionColorTexture[]
            {
                 
                new VertexPositionColorTexture(new Vector3( 1, 0, 1), Color,new Vector2(1,1)),
                new VertexPositionColorTexture(new Vector3( 1, 0,-1), Color,new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(-1, 0,-1), Color,new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(-1, 0, 1), Color,new Vector2(0,1)),
            };




        }

        protected override void SetIndexBuffer()
        {
            indexData = new short[]
            {
                0, 1, 2,
                0, 2, 3,
            };

            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indexData.Length, BufferUsage.None);
            indexBuffer.SetData(indexData);

        }




    }
}
