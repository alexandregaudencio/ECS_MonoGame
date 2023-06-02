using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Managers
{
    public  class TimeManager : GameComponent
    {
        private static  TimeManager instance;
        private TimeSpan elapsedTime;
        private TimeSpan totalTime;

        public TimeSpan ElapsedTime => elapsedTime;
        public TimeSpan TotalTime => totalTime;
        public static TimeManager Instance => instance;
            
        public TimeManager(Game game) : base(game) 
        { 
            instance = this;
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime = gameTime.ElapsedGameTime;
            totalTime = gameTime.TotalGameTime;

            base.Update(gameTime);
        }



    }
}
