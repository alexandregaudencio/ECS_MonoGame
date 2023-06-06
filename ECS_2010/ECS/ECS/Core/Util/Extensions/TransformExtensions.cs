using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECS.Core.Util.Extensions
{
    public static class TransformExtensions
    {

        public static Vector3 ToEulerAngles(this Quaternion quaternion)
        {
            Vector3 rotation;

            double sqw = quaternion.W * quaternion.W;
            double sqx = quaternion.X * quaternion.X;
            double sqy = quaternion.Y * quaternion.Y;
            double sqz = quaternion.Z * quaternion.Z;

            // Roll (x-axis rotation)
            double rollRad = Math.Atan2(2.0 * (quaternion.Y * quaternion.Z + quaternion.W * quaternion.X), sqw - sqx - sqy + sqz);
            rotation.X = (float)rollRad;

            // Pitch (y-axis rotation)
            double pitchRad = Math.Asin(-2.0 * (quaternion.X * quaternion.Z - quaternion.W * quaternion.Y));
            rotation.Y = (float)pitchRad;

            // Yaw (z-axis rotation)
            double yawRad = Math.Atan2(2.0 * (quaternion.X * quaternion.Y + quaternion.W * quaternion.Z), sqw + sqx - sqy - sqz);
            rotation.Z = (float)yawRad;

            return rotation;
         }












     }
            
}
