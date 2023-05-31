using ECS.Core.Boundary;
using ECS.Core.Object;
using Microsoft.Xna.Framework;


namespace ECS.Core.Components.Collision
{
    public interface ICollider
    {
        public Object.GameObject GameObject { get; }
        bool IsColliding { get; }
        public BoundingBox BoundingBox { get; set; }
        public IBoundary Boundary { get; }

        virtual void  OnCollisionEnter(ICollider other) { }
        virtual void OnCollisionExit(ICollider other) { }
        virtual void OnCollisionStay(ICollider other) { }

    }
}
