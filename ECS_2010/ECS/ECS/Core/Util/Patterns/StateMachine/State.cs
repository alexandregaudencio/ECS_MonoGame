using Microsoft.Xna.Framework;
using ECS.Core.Components.Collision;

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

        public abstract void ExitState();
        
        public virtual void UpdateState(GameTime gameTime) { }
        public virtual void OnCollisionEnter(ICollider other) {}

        public virtual void OnCollisionStay(ICollider other) {}

        public virtual void OnCollisionExit(ICollider other) {}
    }
}
