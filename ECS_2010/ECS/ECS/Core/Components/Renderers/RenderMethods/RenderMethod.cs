
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS.Core.Components.Renderers
{
    public abstract class RenderMethod : IRenderMethod
    {
        protected Renderer Renderer { get; set; }
        public PrimitiveType PrimitiveType { get; protected set; }
        public Effect effect;
        public BasicEffect basicEffect;

        public void SetRenderer(Renderer renderer)
        {
            PrimitiveType = PrimitiveType.TriangleList;
            Renderer = renderer;
        }

        public virtual void Draw() { }

        public virtual void Initialize() {

        }

        public virtual void Load() {
            basicEffect = new BasicEffect(Renderer.Game.GraphicsDevice);
        }



        public virtual  void SetColor(Color color) { }

        /// <summary>
        /// Render PrimitiveType lineList.
        /// Call Just in Intitialize() Game Method
        /// </summary>
        /// <param name="value"></param>
        public void RenderOnlyLines(bool value)
        {
            if (value)
            {
                PrimitiveType = PrimitiveType.LineList;
                //SetFillMode(FillMode.WireFrame);
            }
            else
            {
                PrimitiveType = PrimitiveType.TriangleList;
                //SetFillMode(FillMode.Solid);
            }

        }



        private void SetFillMode(FillMode fillMode) 
        {
            RasterizerState rs = new RasterizerState
            {
                CullMode = CullMode.None,
                FillMode = fillMode
            };

            Renderer.Game.GraphicsDevice.RasterizerState = rs;
        }

        public virtual void SetNormalsVisible(bool value) { }
    }
}
