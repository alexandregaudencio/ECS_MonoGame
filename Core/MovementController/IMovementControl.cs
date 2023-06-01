using Microsoft.Xna.Framework.Input;


namespace ECS.Core.MovementController
{
    internal interface IMovementControl
    {
        float Speed { get; set; }
        public bool Active { get; set; }
        public bool IncluseRotation { get; set; }

        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys UP { get; set; }
        public Keys Down { get; set; }

    }
}
