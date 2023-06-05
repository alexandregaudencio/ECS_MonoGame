using ECS.Core.Boundary;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
using ECS.Core.Components.Renderers.Primivites;
using ECS.Core.Entities;
using ECS.Core.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECS.Core.Components.Collision
{
    public class Collider : Entity, ICollider
    {
        private readonly GameObject gameObject;
        private OBB boundary;
        public GameObject GameObject => gameObject;
        public IBoundary Boundary => boundary;
        public Renderer Renderer { get; private set; }
        public bool Active { get; private set; } = true;
        public List<ICollider> Contacts { get;private set; } = new List<ICollider>();
        public bool IsContacting(ICollider collider) => Contacts.Contains(collider);

        public event EventHandler<ICollider> CollisionStay;
        public event EventHandler<ICollider> CollisionEnter;
        public event EventHandler<ICollider> CollisionExit;

        public Collider(Game game, ICameraPerspective iCameraPerspective, GameObject gameObject, bool isVisible = true) : base(game)
        {
            this.gameObject = gameObject;
            Renderer = new Renderer(game, iCameraPerspective, new Cuboid(Color.Black));
            SetVisible(isVisible);
            //TODO: NOT OBB
            boundary = new OBB(Transform);


        }


        public override void Initialize()
        {
            AddChild(Renderer);
            Game.Components.Add(Renderer);
            
            Renderer.RenderMethod.RenderOnlyLines(true);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            boundary.UpdateTransform(gameObject.Transform);

            base.Update(gameTime);
        }

        public void SetActive(bool active)
        {
            Active = active;
            SetVisible(active);
            Renderer.SetActive(active);

            if(active) 
                CollisionManager.Instance.AddColliders(this);
            else 
                CollisionManager.Instance.RemoveColliders(this);


        }

        public void SetVisible(bool value)
        {
            Renderer.Visible = value;
        }

        public void Enter(ICollider other)
        {
            Debug.WriteLine(Active);
            if (!Active) return;

            Contacts.Add(other);
            CollisionEnter?.Invoke(this, other);
            Renderer.RenderMethod.SetColor(Color.Red);
            Debug.WriteLine("collision enter");

        }

        public void Stay(ICollider other)
        {
            if (!Active) return;

            CollisionStay?.Invoke(this, other);
            Debug.WriteLine("collision SATY");

        }

        public void Exit(ICollider other)
        {
            if (!Active) return;

            Contacts.Remove(other);
            CollisionExit?.Invoke(this, other);
            Renderer.RenderMethod.SetColor(Color.Green);
            Debug.WriteLine("collision EXIT");


        }


    }
}
