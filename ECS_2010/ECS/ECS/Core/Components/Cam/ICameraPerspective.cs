using Microsoft.Xna.Framework;

namespace ECS.Core.Components.Cam
{
    public interface ICameraPerspective
    {
        Matrix View { get; }
        Matrix Projection { get; }

    }
}
