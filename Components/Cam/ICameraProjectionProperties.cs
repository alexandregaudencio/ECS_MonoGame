using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components.Cam
{
    public interface ICameraProjectionProperties
    {
        float FieldOfView { get; }
        float AspectRatio { get; }
        float NearPlaneDistance { get; }   
        float FarPlaneDistance { get; }
    }
}
