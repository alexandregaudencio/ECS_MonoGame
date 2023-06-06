using ECS.Core.Components;
using Microsoft.Xna.Framework;



namespace ECS.Core.Boundary
{
    public class OBB : IBoundary
    {
        private Transform transform;
        //private BoundType _type;
        public BoundingBox Box { get; set; }

        public OBB(Transform transform)
        {
            this.transform = transform;
        }



        //public BoundType Type => _type;

        //public float MinX => Transform.Translation.X - Transform.Scale.X * -Transform.World.Backward.X;

        //public float MinY => Transform.Translation.Y - Transform.Scale.Y * -Transform.World.Backward.Y;

        //public float MinZ => Transform.Translation.Z - Transform.Scale.Z * Transform.World.Backward.Z;

        //public float MaxX => Transform.Translation.X + Transform.Scale.X * Transform.World.Forward.X;

        //public float MaxY => Transform.Translation.Y + Transform.Scale.Y * Transform.World.Forward.Y;

        //public float MaxZ => Transform.Translation.Z + Transform.Scale.Z * Transform.World.Forward.Z;

        //public Vector3 Max => new Vector3(MaxX, MaxY, MaxZ);

        //public Vector3 Min => new Vector3(MinX, MinY, MinZ);
 

        public Transform Transform  { get {   return transform; } }

        public bool Intersects(BoundingBox box)
        {
            return this.Box.Intersects(box);
        }


        //TODO: Fix it
        public bool Intersects(IBoundary other)
        {

            return Intersects(other.Box);

            //if (other == null) return false;
            //return false;

            ////(0,0,0)
            //Vector3 origin = transform.Translation.ToNumerics();
            ////Df - Di
            //Vector3 distance = -transform.Translation.ToNumerics() + other.Transform.Translation.ToNumerics(); /*new Vector3(-transform.Translation.X + other.Transform.World.Translation.X,-transform.World.Translation.Y + other.Transform.Translation.Y,-transform.Translation.Z+ other.Transform.Translation.Z);*/


            ////direction from the center to target
            //Vector3 a = Vector3.Normalize(distance) * transform.Scale.ToNumerics();
            //Vector3 b = Vector3.Normalize(-distance) * other.Transform.Scale.ToNumerics();

            //if (a.X > b.X && a.Y > b.Y && a.Z > b.Z) return true;
            //if (a.X < b.X && a.Y < b.Y && a.Z < b.Z) return true;

            //return false;

            //////float lengthScale = transform.Scale.ToNumerics().Length();
            //////Vector3 contactPoint = direction * lengthScale;


            ////if (Max.X > other.Min.X && Min.X < other.Min.X) return true;
            //if(other.Max.X > Min.X && other.Max.X < Max.X) return true; //intersecta no x

            //return false;
            ////(a.X > -b.X && -a.X < -b.Y) //intersecta no x



            ////1-7
            //if (GetCorners[1].X > -other.GetCorners[7].X && GetCorners[1].Y > -other.GetCorners[7].Y && GetCorners[1].Z > -other.GetCorners[7].Z) return true;
            ////0-6
            //if (GetCorners[0].X > -other.GetCorners[6].X && GetCorners[0].Y > -other.GetCorners[6].Y && GetCorners[0].Z > -other.GetCorners[6].Z) return true;
            ////3-5
            //if (GetCorners[3].X > -other.GetCorners[5].X && GetCorners[3].Y > -other.GetCorners[5].Y && GetCorners[3].Z > -other.GetCorners[5].Z) return true;
            ////4-2
            //if (GetCorners[4].X > -other.GetCorners[2].X && GetCorners[4].Y > -other.GetCorners[2].Y && GetCorners[4].Z > -other.GetCorners[2].Z) return true;

            //return false;

            #region AABB
            //if (Max.X >= other.Min.X && Min.X <= other.Max.X)
            //{
            //    if (Max.Y < other.Min.Y || Min.Y > other.Max.Y)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return Max.Z >= other.Min.Z && Min.Z <= other.Max.Z;
            //    }
            //}
            //else
            //{
            //    return false;
            //}



            #endregion

        }


        public void UpdateTransform(Transform transform)
        {
            this.transform = transform;

            Box = new BoundingBox(Transform.Translation - transform.Scale,
                transform.Translation + transform.Scale);
        }

    }
}
