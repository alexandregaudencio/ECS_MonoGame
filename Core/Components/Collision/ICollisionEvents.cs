using System;

namespace ECS.Core.Components.Collision
{
    public interface ICollisionEvents
    {
        event EventHandler<ICollider> CollisionStay;
        event EventHandler<ICollider> CollisionEnter;
        event EventHandler<ICollider> CollisionExit;
    }
}
