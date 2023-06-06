using ECS.Core.Components;
using Microsoft.Xna.Framework;

namespace ECS.Core.Boundary
{
    public enum BoundType
    {
        //AABB,
        OBB,
        SB
    }
    public interface IBoundary
    {
        Transform Transform { get; }
        //BoundType Type { get; }
        BoundingBox Box { get; set; }
        bool Intersects(BoundingBox box);


        //float MinX { get; }
        //float MinY { get; }
        //float MinZ { get; }
        //float MaxX { get; }
        //float MaxY { get; }
        //float MaxZ { get; }

        //Vector3 Max { get; }
        //Vector3 Min { get; }

        bool Intersects(IBoundary other);

        void UpdateTransform(Transform transform);
        //void UpdateTransform(Transform transform);
    }
}
