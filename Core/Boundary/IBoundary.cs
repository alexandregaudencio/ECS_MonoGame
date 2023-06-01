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
        Microsoft.Xna.Framework.BoundingBox Box { get; set; }
        bool Intersects(Microsoft.Xna.Framework.BoundingBox box);


        float MinX { get;  }
        float MinY { get; }
        float MinZ { get;  }
        float MaxX { get;  }
        float MaxY { get; }
        float MaxZ { get;  }
        
        Vector3 Max { get; }
        Vector3 Min { get; }

        bool Intersects(IBoundary other);
        Vector3[] GetCorners { get; }
        void UpdateTransform(Transform transform);
        //void UpdateTransform(Transform transform);
    }
}
