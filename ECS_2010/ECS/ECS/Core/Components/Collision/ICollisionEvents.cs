using System;

namespace ECS.Core.Components.Collision
{
    public interface ICollisionEvents
    {
        event Action<ICollider> CollisionStay;
        event Action<ICollider> CollisionEnter;
        event Action<ICollider> CollisionExit;
    }
}
