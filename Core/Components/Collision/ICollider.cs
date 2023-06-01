using ECS.Core.Boundary;
using ECS.Core.Object;
using System;
using System.Collections.Generic;

namespace ECS.Core.Components.Collision
{
    public interface ICollider
    {
        public GameObject GameObject { get; }
        public IBoundary Boundary { get; }
        bool IsContacting(ICollider collider);

        List<ICollider> Contacts { get; set; }

        public event EventHandler<ICollider> CollisionStay;
        public event EventHandler<ICollider> CollisionEnter;
        public event EventHandler<ICollider> CollisionExit;

        virtual void Enter(ICollider other) { }
        virtual void Exit(ICollider other) { }
        virtual void Stay(ICollider other) { }

    }
}
