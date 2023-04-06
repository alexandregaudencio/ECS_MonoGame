﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components.Cam
{
    internal interface ICameraViewProperties
    {

        Vector3 CameraPosition { get; set; } 
        Vector3 CameraTarget { get; set; }
        Vector3 CameraUpVector { get; set; }

        Matrix View { get => Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector); }
        
    }
}
