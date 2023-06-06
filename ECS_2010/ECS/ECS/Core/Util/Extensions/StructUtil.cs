using ECS.Core.Components;
using Microsoft.Xna.Framework;
using System;

namespace ECS.Core.Util.Extensions
{
    internal static class StructUtil
    {
        public static int RandomColorIndex { 
            get { return new Random().Next(255); } 
        }

        public static Color Random(this Color color) 
        { 
            return new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex);
        }
        
        public static Vector3 ColorToVector3(this Color color)
        {
            float rUnit = (float)(color.G / 255.0f);
            float gUnit = (float)(color.G / 255.0f);
            float bUnit = (float)(color.G / 255.0f);

            return new Vector3(rUnit, gUnit, bUnit);

        }

        public static void ClampPosition(this Transform transform, BoundingBox bound)
        {
            Vector3 vector3 = new Vector3();
            vector3.X = MathHelper.Clamp(transform.Translation.X, bound.Min.X, bound.Max.X);
            vector3.X = MathHelper.Clamp(transform.Translation.Y, bound.Min.Y, bound.Max.Y);
            vector3.Z = MathHelper.Clamp(transform.Translation.Z, bound.Min.Z, bound.Max.Z);
            transform.SetTranslation(vector3);
        }


        public static void Clamp(this Vector3 vector3, Vector3 value)
        {
            vector3.X = MathHelper.Clamp(vector3.X, -value.X, value.X);
            vector3.Y = MathHelper.Clamp(vector3.Y, -value.Y, value.Y);
            vector3.Z = MathHelper.Clamp(vector3.Z, -value.Z, value.Z);
        }



    }
}
