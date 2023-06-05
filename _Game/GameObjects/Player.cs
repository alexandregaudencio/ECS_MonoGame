using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using ECS.Core.Object;
using Microsoft.Xna.Framework;


namespace ECS._Game.GameObjects
{
    public class Player : GameObject
    {
        public Vector3 LastPosition { get; set; } = Vector3.Zero;

        public Player(Game game, ICameraPerspective cameraPerspective) : base(game, cameraPerspective)
        {
            Renderer = new Renderer(game, cameraPerspective, new Cuboid(Color.White, "metal"));
            MovementControl.SetActive(true);
        }

        public override void Initialize()
        {
            Collider.SetActive(true);
            
            base.Initialize();
        }

        public override void OnCollisionEnter(object sender, ICollider other)
        {
            MovementControl.SetActive(false);
            MovementControl.RestorePosition(Transform);
            base.OnCollisionEnter(sender, other);
        }


        public override void OnCollisionStay(object sender, ICollider other)
        {

            base.OnCollisionStay(sender, other);
        }

        public override void OnCollisionExit(object sender, ICollider other)
        {
            MovementControl.SetActive(true);

            base.OnCollisionExit(sender, other);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }



    }
}
