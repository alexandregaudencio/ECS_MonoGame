using ECS.Core.Components.Cam;
using Microsoft.Xna.Framework;

namespace ECS.Core.Object
{
    internal class Box : GameObject
    {
        public Box(Game game, ICameraPerspective cameraPerspective, string modelPath = "") : base(game, cameraPerspective, modelPath)
        {
            //Transform.SetScale(Vector3.One * 0.05f);
            //Transform.Translate(Vector3.UnitZ );

        }


        public override void Initialize()
        {

            //AddChild(Collider);
            //AddChild(ModelRenderer);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }



    }
}
