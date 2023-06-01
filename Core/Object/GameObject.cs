using ECS.Core.Components.Cam;
using ECS.Core.Components.Collision;
using ECS.Core.Components.Renderer;
using ECS.Core.Entities;
using ECS.Core.MovementController;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ECS.Core.Object
{
    public abstract class GameObject : Entity
    {
        protected ModelRenderer ModelRenderer { get; set; }
        protected Collider Collider { get; private set; }
        //protected Physics Physics { get; private set; }
        public DirectionalMovementControl MovementControl { get; private set; }

        public GameObject(Game game, ICameraPerspective cameraPerspective, string modelPath = "") : base(game)
        {
            ModelRenderer = new ModelRenderer(game, cameraPerspective, Transform, modelPath);
            Collider = new Collider(game, cameraPerspective, this);
            MovementControl = new DirectionalMovementControl(game, Transform);

            //Physics = new Physics(game, Transform, Collider);
            //Physics.Active = true;

            Collider.CollisionStay += OnCollisionStay;
            Collider.CollisionEnter += OnCollisionEnter;
            Collider.CollisionExit += OnCollisionExit;


        }


        public override void Initialize()
        {
            AddChild(Collider);
            AddChild(ModelRenderer);

            Game.Components.Add(ModelRenderer);
            Game.Components.Add(Collider);

            //Game.Components.Add(Physics);
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
