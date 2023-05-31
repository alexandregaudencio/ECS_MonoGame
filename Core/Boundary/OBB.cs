using ECS.Core.Components;
using ECS.Core.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using Vector3 = System.Numerics.Vector3;

namespace ECS.Core.Boundary
{
    public class OBB : IBoundary
    {
        private Transform transform;
        private BoundType _type;        

        public OBB(Transform transform)
        {
            this.transform = transform;
        }

        public BoundType Type => _type;

        public float MinX => Transform.Translation.X - Transform.Scale.X;

        public float MinY => Transform.Translation.Y - Transform.Scale.Y;

        public float MinZ => Transform.Translation.Z - Transform.Scale.Z;

        public float MaxX => Transform.Translation.X + Transform.Scale.X;

        public float MaxY => Transform.Translation.Y + Transform.Scale.Y;

        public float MaxZ => Transform.Translation.Z + Transform.Scale.Z;

        public Vector3 Max => new Vector3(MaxX, MaxY, MaxZ);

        public Vector3 Min => new Vector3(MinX, MinY, MinZ);

        public Transform Transform => transform;

        public bool Intersects(IBoundary other)
        {
            if (other == null) return false;




            #region AABB
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


            ////second method (alternative)
            //bool intersectsX = Math.Abs(Transform.Translation.X - other.Transform.Translation.X) < (Transform.Scale.X + other.Transform.Scale.X) / 2;
            //bool intersectsY = Math.Abs(Transform.Translation.Y - other.Transform.Translation.Y) < (Transform.Scale.Y + other.Transform.Scale.Y) / 2;
            //bool intersectsZ = Math.Abs(Transform.Translation.Z - other.Transform.Translation.Z) < (Transform.Scale.Z + other.Transform.Scale.Z) / 2;

            //return intersectsX && intersectsY && intersectsZ;
            #endregion

        }


        public void UpdateTransform(Transform transform) 
        {

            this.transform = transform;
        }

    }
}
