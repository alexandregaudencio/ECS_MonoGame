using Microsoft.Xna.Framework;

namespace ECS.Core.Managers
{
    public  class Time : GameComponent
    {
        private static  Time instance;
        private float elapsedTime;
        private float releasedTime;

        /// <summary>
        /// Delta Time in seconds 
        /// </summary>
        public float ElapsedTime {get { return elapsedTime;}}
        /// <summary>
        /// Released Time in seconds
        /// </summary>
        public float ReleasedTime {get{ return releasedTime;}}
        public static Time Instance { get { return instance; } }
            
        public Time(Game game) : base(game) 
        { 
            instance = this;

        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime = gameTime.ElapsedGameTime.Milliseconds/1000.0f;
            releasedTime += gameTime.ElapsedGameTime.Milliseconds/1000.0f;

            base.Update(gameTime);
        }



    }
}
