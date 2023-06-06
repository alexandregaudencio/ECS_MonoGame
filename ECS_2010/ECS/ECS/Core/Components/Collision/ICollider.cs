using ECS.Core.Boundary;
using ECS.Core.Object;
using System.Collections.Generic;

namespace ECS.Core.Components.Collision
{
    public interface ICollider : ICollisionEvents, ICollisionState, IActivable
    {
        GameObject GameObject { get; }
        IBoundary Boundary { get; }
        List<ICollider> Contacts { get; }
        bool IsColliding { get; }
        bool IsContacting(ICollider collider);


    }
}
