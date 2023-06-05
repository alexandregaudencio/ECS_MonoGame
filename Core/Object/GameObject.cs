using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderers;
using ECS.Core.Entities;
using ECS.Core.MovementController;
using Microsoft.Xna.Framework;

namespace ECS.Core.Object
{
    public abstract class GameObject : Entity
    {
        public Renderer Renderer { get;protected set; }
        public Collider Collider { get; protected set; }
        //protected Physics Physics { get; private set; }
        public DirectionalMovementControl MovementControl { get; private set; }

        public GameObject(Game game, ICameraPerspective cameraPerspective) : base(game)
        {
            Collider = new Collider(game, cameraPerspective, this);
            MovementControl = new DirectionalMovementControl(game, Transform);
            //Renderer = new Renderer(game, cameraPerspective, Transform, new ModelRenderMethod());
            //Physics = new Physics(game, Transform, Collider);
            //Physics.Active = true;
            



            Collider.CollisionStay += OnCollisionStay;
            Collider.CollisionEnter += OnCollisionEnter;
            Collider.CollisionExit += OnCollisionExit;


        }

        protected override void Dispose(bool disposing)
        {
            Collider.CollisionStay -= OnCollisionStay;
            Collider.CollisionEnter -= OnCollisionEnter;
            Collider.CollisionExit -= OnCollisionExit;

            base.Dispose(disposing);
        }

        public override void Initialize()
        {
            AddChild(Collider);
            AddChild(Renderer);

            if(Renderer != null) Game.Components.Add(Renderer);
            Game.Components.Add(Collider);
            Game.Components.Add(MovementControl);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            MovementControl.UpdateTransform(Transform);
            base.Update(gameTime);
        }


        public void SetObjectOnFloorY()
        {
            Transform.Translate(Vector3.UnitY * Transform.Scale.Y);

        }

        public virtual void OnCollisionEnter(object sender, ICollider other)
        {

        }
        public virtual void OnCollisionStay(object sender, ICollider other)
        {
        }

        public virtual void OnCollisionExit(object sender, ICollider other)
        {
        }


    }
}
