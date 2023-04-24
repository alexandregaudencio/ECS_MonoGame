using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Components.Cam
{
    public interface ICameraProjectionProperties
    {
        float FieldOfView { get; set; }
        float AspectRatio { get; set; }
        float NearPlaneDistance { get; set; }
        float FarPlaneDistance { get; }
    }
}
