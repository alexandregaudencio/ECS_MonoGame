using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ECS.Core.Components;
using Microsoft.Xna.Framework.Input;
using ECS.Core.Managers;

namespace ECS.Core.MovementController
{
    public abstract class MovementControl : GameComponent, IMovementControl
    {
        private Transform transform;
        public float Speed { get; set; } 
        public bool Active { get; private set; } 
        public Keys Left { get; set; } 
        public Keys Right { get; set; } 
        public Keys UP { get; set; } 
        public Keys Down { get; set; } 
        public bool IncluseRotation { get; set; } 
        public void SetActive(bool active) { Active = active;}
        public Vector3 LastPosition { get; set; }   


        public MovementControl(Game game, Transform transform) : base(game)
        {
            Speed = 5;
            Active = false;
            Left = Keys.A;
            Right= Keys.D;
            UP = Keys.W;
            Down = Keys.S;
            IncluseRotation = false;

            this.transform = transform;
        }

        public override void Initialize()
        {
            LastPosition = transform.Translation;
            base.Initialize();
        }
        public void RestorePosition(Transform transform)
        {
            transform.SetTranslation(LastPosition);
        }

        public abstract void UpdateMovement(Transform transform);
    }
}
