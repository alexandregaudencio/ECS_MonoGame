using Microsoft.Xna.Framework;
using ECS.Core.Components.Collision;

namespace ECS.Core.Util.Patterns.StateMachine
{
    public abstract class StateController : GameComponent
    {

        public State CurrentState { get; set; }

        protected StateController(Game game) : base(game)
        {

        }

        public void SetState(State state)
        {
            if (state == null) return;
            if(CurrentState != null) CurrentState.ExitState();
            CurrentState = state;
            CurrentState.EnterState();
        }


        public override void Update(GameTime gameTime)
        {
            if(CurrentState != null) CurrentState.UpdateState(gameTime);
            base.Update(gameTime);
        }

        public void OnCollisionEnter(ICollider other)
        {
            CurrentState.OnCollisionEnter(other);
        }

        public void OnCollisionStay(ICollider other)
        {
            CurrentState.OnCollisionStay(other);
        }

        public void OnCollisionExit(ICollider other)
        {
            CurrentState.OnCollisionExit(other);
        }

    }
}
