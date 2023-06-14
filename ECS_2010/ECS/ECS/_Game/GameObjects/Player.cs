using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderers;
using ECS.Core.Object;
using Microsoft.Xna.Framework;


namespace ECS._Game.GameObjects
{
    public class Player : GameObject
    {
        public Vector3 LastPosition { get; set; }

        public Player(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            LastPosition = Vector3.Zero;
            Renderer = new Renderer(game, cameraPerspective, new WireCuboid(Color.White, "metal2"));
            MovementControl.SetActive(true);
            Collider.SetActive(true);

        }

        public override void Initialize()
        {
            //Collider.SetActive(true);
            Renderer.RenderMethod.RenderOnlyLines(true);
            //Collider.Renderer.RenderMethod.SetColor(Color.Red);
            base.Initialize();
        }

        public override void OnCollisionEnter(ICollider other)
        {
            MovementControl.SetActive(false);
            MovementControl.RestorePosition(Transform);

            Renderer.RenderMethod.SetColor(Color.Red);
            base.OnCollisionEnter(other);

        }


        public override void OnCollisionStay(ICollider other)
        {

            base.OnCollisionStay(other);
        }

        public override void OnCollisionExit(ICollider other)
        {
            MovementControl.SetActive(true);
            Renderer.RenderMethod.SetColor(Color.Blue);
            base.OnCollisionExit(other);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }



    }
}
