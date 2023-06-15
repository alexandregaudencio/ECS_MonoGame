using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Util.Patterns.StateMachine;
using Microsoft.Xna.Framework;
using ECS._Game.GameObjects.Boat;
using ECS.Core.Object;

namespace ECS._Game
{
    class BoatStateMachineController : StateController
    {

        private readonly OnBoard onBoard;

        public BoatStateMachineController(Game game, GameObject gameObject) : base(game) 
        {
            onBoard = new OnBoard(this, gameObject);
            CurrentState = onBoard;
        }
    }
}
