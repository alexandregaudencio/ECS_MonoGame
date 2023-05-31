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
    internal interface IBoundary
    {
        BoundType Type { get; }

        float MinX { get;  }
        float MinY { get; }
        float MinZ { get;  }
        float MaxX { get;  }
        float MaxY { get; }
        float MaxZ { get;  }
        
        Vector3 Max { get; }
        Vector3 Min { get; }



        bool Intersect(IBoundary other);


    }
}
