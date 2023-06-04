
namespace ECS.Core.Components.Collision
{
    public interface ICollisionState
    {
        void Enter(ICollider collider);
        void Stay(ICollider collider);
        void Exit(ICollider collider);
    }
}
