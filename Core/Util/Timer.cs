using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Core.Util
{

    public class Timer : GameComponent
    {
        public float MaxTime { get; private set; } = 0;
        public float CurrentTime { get; private set; } = 0;
        public bool IsReleasing { get; private set; } = false;

        private int Minutes => (int)MathF.Floor(CurrentTime / 60);
        private int Seconds => (int)MathF.Floor(CurrentTime % 60);



        public event Action<float> TimeChange;
        public event Action Init;
        public event Action Paused;
        public event Action Finish;


        public Timer(Game game, float maxTime) : base(game)
        {
            MaxTime = maxTime;
        }

        public override void Update(GameTime gameTime)
        {
            if (IsReleasing) UpdateTime();
            base.Update(gameTime);
        }

        //public void SetMaxTime(float maxTime)
        //{
        //    MaxTime = maxTime;
        //}

        public void Start()
        {
            Init?.Invoke();
            IsReleasing = true;
        }
        public void Pause()
        {
            Paused?.Invoke();
            IsReleasing = false;
        }
        public void Stop()
        {
            Finish?.Invoke();
        }

        public void Reset()
        {
            Stop();
            CurrentTime = MaxTime;
        }

        public void UpdateTime()
        {

        }

        //private IEnumerator ClockUpdate()
        //{
        //    Init?.Invoke();
        //    currentTime = maxTime;
        //    while (currentTime > 0)
        //    {
        //        yield return new WaitForSeconds(1);
        //        if (currentTime > 0)
        //        {
        //            currentTime--;
        //            TimeChange?.Invoke(currentTime);
        //        }
        //        else
        //        {
        //            Finish?.Invoke();
        //        }
        //    }
        //}


        public string ClockFormat()
        {
            return string.Format("{0:0}:{1:00}", Minutes, Seconds);
            
        }


    }


}
