using Microsoft.Xna.Framework;

namespace ECS.Core.Components.Cam
{
    internal interface ICameraViewProperties
    {
        Vector3 CameraTarget { get; set; }
        Vector3 CameraUpVector { get; set; }

    }
}
