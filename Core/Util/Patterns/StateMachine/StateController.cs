using Microsoft.Xna.Framework;

namespace ECS.Core.Util.Patterns.StateMachine
{
    public abstract class StateController : GameComponent
    {
        public abstract State CurrentState { get; set; }

        protected StateController(Game game) : base(game)
        {

        }

        public void SetState(State state)
        {
            CurrentState?.ExitState();
            CurrentState = state;
            CurrentState?.EnterState();
        }


        public override void Update(GameTime gameTime)
        {
            CurrentState?.UpdateState(gameTime);
            base.Update(gameTime);
        }



    }
}
