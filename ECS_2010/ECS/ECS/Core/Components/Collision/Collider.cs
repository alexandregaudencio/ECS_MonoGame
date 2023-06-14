using ECS.Core.Boundary;
using ECS.Core.Components.Cam;
using ECS.Core.Components.Renderers;
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
        public GameObject GameObject {get{ return gameObject;}}
        public IBoundary Boundary {get{ return boundary;}}
        public Renderer Renderer { get; private set; }
        public bool Active { get; private set; } 
        public List<ICollider> Contacts { get;private set; } 
        public bool IsColliding {get{ return Contacts.Count >0;}}
        public bool IsContacting(ICollider collider){ return Contacts.Contains(collider);}

        public event Action<ICollider> CollisionStay;
        public event Action<ICollider> CollisionEnter;
        public event Action<ICollider> CollisionExit;

        public Collider(Game game, ICameraPerspective iCameraPerspective, GameObject gameObject, bool isVisible = true) : base(game)
        {
            Active = true;
            Contacts = new List<ICollider>();

            this.gameObject = gameObject;
            Renderer = new Renderer(game, iCameraPerspective, new WireCuboid(Color.Black));
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
            if (!Active) return;

            Contacts.Add(other);
            if(CollisionEnter != null) CollisionEnter.Invoke(other);
            Renderer.RenderMethod.SetColor(Color.Red);

        }

        public void Stay(ICollider other)
        {
            if (!Active) return;

            if(CollisionStay != null) CollisionStay.Invoke(other);

        }

        public void Exit(ICollider other)
        {
            if (!Active) return;

            Contacts.Remove(other);
            if(CollisionExit != null) CollisionExit.Invoke(other);
            Renderer.RenderMethod.SetColor(Color.Green);


        }


    }
}
