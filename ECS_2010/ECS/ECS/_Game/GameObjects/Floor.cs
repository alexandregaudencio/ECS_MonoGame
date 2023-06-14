using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;

using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECS._Game.GameObjects
{
    internal class Floor : GameObject
    {
        public Floor(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new HeightMapGrid(Vector2.One*100, "grass", "mountain1", "snow"));
            //SnowController.instance.AddRenderer(Renderer);
            Collider.SetActive(false);
            Renderer.SetActive(true);

            Transform.SetScale(new Vector3(1, 1f, 1)*2);
            Transform.Translate(-Vector3.UnitY * 25);
            Collider.Transform.IncreaseScale(Vector3.One * 2.7f);

        }

        public override void Initialize()
        {
            Collider.SetActive(true);
            Collider.SetVisible(true);
            Renderer.RenderMethod.SetNormalsVisible(true);

            Transform.SetMinYOnFloor();
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.F1)) 
                Renderer.RenderMethod.SetNormalsVisible(true);
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
                Renderer.RenderMethod.SetNormalsVisible(false);
            base.Update(gameTime);
        }

    }
}
