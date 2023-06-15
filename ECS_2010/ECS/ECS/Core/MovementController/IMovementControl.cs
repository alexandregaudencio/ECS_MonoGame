using Microsoft.Xna.Framework.Input;
using ECS.Core.Components;


namespace ECS.Core.MovementController
{
    public interface IMovementControl : IActivable
    {
        float Speed { get; set; }
        bool IncluseRotation { get; set; }

        Keys Left { get; set; }
        Keys Right { get; set; }
        Keys UP { get; set; }
        Keys Down { get; set; }

        void RestorePosition(Transform transform);
        void UpdateMovement(Transform transform);

    }
}
