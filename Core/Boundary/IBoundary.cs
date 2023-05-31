using ECS.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Boundary
{
    public enum BoundType
    {
        //AABB,
        OBB,
        //SPHERE
    }
    public interface IBoundary
    {
        Transform Transform { get; }
        BoundType Type { get; }

        float MinX { get;  }
        float MinY { get; }
        float MinZ { get;  }
        float MaxX { get;  }
        float MaxY { get; }
        float MaxZ { get;  }
        
        Vector3 Max { get; }
        Vector3 Min { get; }

        bool Intersects(IBoundary other);

        void UpdateTransform(Transform transform);
        //void UpdateTransform(Transform transform);
    }
}
