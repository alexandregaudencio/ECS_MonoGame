using Microsoft.Xna.Framework;

namespace ECS.Core.Util.Patterns.StateMachine
{
    public abstract class State
    {
        protected StateController StateController { get; private set; }
        protected State(StateController stateController) 
        {
            StateController = stateController;
        }
        public abstract void EnterState();
        public abstract void UpdateState(GameTime gameTime);
        public abstract void ExitState();


    }
}
