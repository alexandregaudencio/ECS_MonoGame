using ECS.Core.Boundary;
using ECS.Core.Components.Cam;
using ECS.Core.Object;
using ECS.Core.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ECS.Core.Components.Collision
{
    public class Collider : Entity.Entity, ICollider
    {
        private readonly Cuboid wireframe;
        private readonly GameObject gameObject;
        public GameObject GameObject => gameObject;
        private OBB boundary;
        public IBoundary Boundary => boundary;
        public List<ICollider> Contacts { get;private set; } = new List<ICollider>();
        public bool IsContacting(ICollider collider) => Contacts.Contains(collider);

        public event EventHandler<ICollider> CollisionStay;
        public event EventHandler<ICollider> CollisionEnter;
        public event EventHandler<ICollider> CollisionExit;

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

            base.Update(gameTime);
        }


        public void SetVisible(bool value)
        {
            wireframe.Visible = value;
        }

        public void SetColor(Color color)
        {
            wireframe.SetColor(color);
        }

        public void Enter(ICollider other)
        {
            Contacts.Add(other);
            CollisionEnter?.Invoke(this, other);
            wireframe.SetColor(Color.Red);

        }

        public void Stay(ICollider other)
        {
            CollisionStay?.Invoke(this, other);
        }

        public void Exit(ICollider other)
        {
            Contacts.Remove(other);
            CollisionExit?.Invoke(this, other);
            wireframe.SetColor(Color.Green);

        }


    }
}
