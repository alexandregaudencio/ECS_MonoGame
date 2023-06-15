using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS.Core.Util.Patterns.StateMachine;
using ECS.Core.Object;
using Microsoft.Xna.Framework;

namespace ECS._Game.GameObjects.Boat
{
    class OnBoard : State
    {
        private GameObject gameObject;
        public OnBoard(StateController stateController, GameObject gameObject)
            : base(stateController)
        {
            this.gameObject = gameObject;

        }
        public override void EnterState()
        {
        }

        public override void ExitState()
        {

        }


        public override void UpdateState(Microsoft.Xna.Framework.GameTime gameTime)
        {
            gameObject.Transform.Translate(Vector3.UnitX);
            base.UpdateState(gameTime);
        }
    }
}
