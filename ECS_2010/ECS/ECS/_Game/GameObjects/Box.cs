using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects
{
    public class Box : GameObject
    {

        public Box(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Cuboid(Color.White, "madeira", "snow"));
            //SnowController.instance.AddRenderer(Renderer);
            Renderer.SetActive(true);
            Collider.SetActive(true);

            

        }

        public override void Initialize()
        {
            Collider.SetVisible(true);


            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }

}
