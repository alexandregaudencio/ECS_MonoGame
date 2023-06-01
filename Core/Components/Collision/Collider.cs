using ECS.Core.Boundary;
using ECS.Core.Components.Cam;
using ECS.Core.Entities;
using ECS.Core.Object;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace ECS.Core.Components.Collision
{
    public class Collider : Entity, ICollider
    {
        private readonly Cuboid wireframe;
        
        private bool isColliding;
        public bool IsColliding => isColliding;

        private readonly GameObject gameObject;
        public GameObject GameObject => gameObject;

        private OBB boundary;
        public IBoundary Boundary => boundary;

        public event EventHandler<ICollider> CollisionStay;
        public Collider(Game game, ICameraPerspective iCameraPerspective, GameObject gameObject, bool isVisible = true) : base(game)
        {
            this.gameObject = gameObject;
            wireframe = new Cuboid(game, iCameraPerspective, Color.Green);
            boundary = new OBB(Transform);
            
            SetVisible(isVisible);
        }


        public override void Initialize()
        {
            AddChild(wireframe);
            Game.Components.Add(wireframe);

            wireframe.SetPrimitiveType(PrimitiveType.LineList);
            CollisionManager.Instance.AddColliders(this);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            boundary.UpdateTransform(gameObject.Transform);
            //boundary.Transform.SetRotation(Vector3.Zero);
            //Debug.WriteLine("MAX: " +string.Format("forward:{0:0}", boundary.Transform.World.Forward.x));
            //Debug.WriteLine("MAX: " + MathF.Cos(MathHelper.ToDegrees(boundary.Transform.World.Forward.X)));
            //Debug.WriteLine("MAX: "+boundary.Transform.World.Forward);



            base.Update(gameTime);
        }


        public void SetVisible(bool value)
        {
            wireframe.Visible  = value;
        }

        public void SetColor(Color color)
        {
            wireframe.SetColor(color);
        }


        public  void OnCollisionEnter(ICollider other)
        {
            isColliding = true;

            Debug.WriteLine(guid+ " On collision Enter");
            wireframe.SetColor(Color.Red);
        }

        public  void OnCollisionExit(ICollider other)
        {

            isColliding = false;
            wireframe.SetColor(Color.Green);

            Debug.WriteLine(" On collision exit");

        }

        public  void OnCollisionStay(ICollider other)
        {
            //Debug.WriteLine(other.GameObject.GetTypeInfo());
            CollisionStay?.Invoke(this, other);

        }
    }
}
