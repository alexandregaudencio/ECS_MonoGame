using Microsoft.Xna.Framework.Input;


namespace ECS.Core.MovementController
{
    internal interface IMovementControl : IActivable
    {
        float Speed { get; set; }
        bool IncluseRotation { get; set; }

        Keys Left { get; set; }
        Keys Right { get; set; }
        Keys UP { get; set; }
        Keys Down { get; set; }

    }
}
