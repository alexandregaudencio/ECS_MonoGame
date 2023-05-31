using ECS.Core.Components;
using ECS.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Boundary
{
    public class OBB : IBoundary
    {
        private BoundType _type;
        private Transform transform;
        public OBB(Transform transform) 
        { 
            this.transform = transform;
        }

        public BoundType Type => _type;

        public float MinX => transform.Translation.X + transform.Scale.X;

        public float MinY => transform.Translation.X - transform.Scale.X;

        public float MinZ => transform.Translation.Y + transform.Scale.Y;

        public float MaxX => transform.Translation.Y - transform.Scale.Y;

        public float MaxY => transform.Translation.Z + transform.Scale.Z;

        public float MaxZ => transform.Translation.Z - transform.Scale.Z;

        public Vector3 Max => new Vector3(MaxX, MaxY, MaxZ);

        public Vector3 Min => new Vector3(MinX, MinY, MinZ);

        BoundType IBoundary.Type => throw new NotImplementedException();

        float IBoundary.MinX => throw new NotImplementedException();

        float IBoundary.MinY => throw new NotImplementedException();

        float IBoundary.MinZ => throw new NotImplementedException();

        float IBoundary.MaxX => throw new NotImplementedException();

        float IBoundary.MaxY => throw new NotImplementedException();

        float IBoundary.MaxZ => throw new NotImplementedException();

        Vector3 IBoundary.Max => throw new NotImplementedException();

        Vector3 IBoundary.Min => throw new NotImplementedException();

        //bool Intersect(IBoundary other)
        //{
        //    if(other == null) return false;

        //    if (Max.X >= other.Min.X && Min.X <= other.Max.X)
        //    {
        //        if (Max.Y < other.Min.Y || Min.Y > other.Max.Y)
        //        {
        //            return  false;
        //        }
        //        else
        //        {
        //            return Max.Z >= other.Min.Z && Min.Z <= other.Max.Z;
        //        }
        //    }
        //    else
        //    {
        //        return  false;
        //    }
        //}

        bool IBoundary.Intersect(IBoundary other)
        {
            if (other == null) return false;

            if (Max.X >= other.Min.X && Min.X <= other.Max.X)
            {
                if (Max.Y < other.Min.Y || Min.Y > other.Max.Y)
                {
                    return false;
                }
                else
                {
                    return Max.Z >= other.Min.Z && Min.Z <= other.Max.Z;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
