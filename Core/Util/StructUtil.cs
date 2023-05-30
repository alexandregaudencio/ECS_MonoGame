using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Numerics;



namespace ECS.Core.Util
{
    internal static class StructUtil
    {
        public static int RandomColorIndex => new Random().Next(255);
        public static Color RandomColor(this Color color) => new Color(RandomColorIndex, RandomColorIndex, RandomColorIndex);
        public static Microsoft.Xna.Framework.Vector3 ColorToVector3(this Color color)
        {
            float rUnit = (float)(color.G / 255.0f);
            float gUnit = (float)(color.G / 255.0f);
            float bUnit = (float)(color.G / 255.0f);
            //Debug.WriteLine(tofloat);
            return new Microsoft.Xna.Framework.Vector3(rUnit, gUnit, bUnit);  

        }



    }
}
