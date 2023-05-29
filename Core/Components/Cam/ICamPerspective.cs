using Microsoft.Xna.Framework;

namespace ECS.Core.Components.Cam
{
    public interface ICamPerspective
    {
        Matrix View { get; }
        Matrix Projection { get; }

    }
}
