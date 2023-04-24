using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Components.Cam
{
    internal interface ICameraViewProperties
    {
        Vector3 CameraTarget { get; set; }
        Vector3 CameraUpVector { get; set; }

    }
}
