//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System.Collections.Generic;


//namespace ECS.Components
//{
//    public class Animator2D : GameComponent
//    {
//        private readonly Dictionary<string, Animation> nameAnimationsPairs = new();
//        private float elapsedTime;
//        public Animation CurrentAnimation { get; set; }
//        private readonly IAnimationRenderUpdate iAnimationRenderUpdate;

//        public Animator2D(Game game,IAnimationRenderUpdate iAnimationRenderUpdate, Dictionary<string,Animation> nameAnimationsPairs) : base(game)
//        {
//            this.iAnimationRenderUpdate = iAnimationRenderUpdate;
//            this.nameAnimationsPairs = nameAnimationsPairs;
//        }


//        public void Play(string animationName)
//        {
//            Animation targetAnimation = nameAnimationsPairs[animationName];
//            if (CurrentAnimation == nameAnimationsPairs[animationName]) return;
//            InitializeAnimation(targetAnimation);

//        }

//        public void Stop()
//        {
//            elapsedTime = 0;
//            CurrentAnimation.CurrentFrame = 1;

//        }
//        private void InitializeAnimation(Animation animation)
//        {
//            CurrentAnimation = animation;
//            iAnimationRenderUpdate.SetTexture2D(CurrentAnimation.CurrentTexture);
//            iAnimationRenderUpdate.SetRectangle(CurrentAnimation.FrameRectangle());
//            elapsedTime = 0;
//        }

//        public override void Update(GameTime gameTime)
//        {
//            if (CurrentAnimation.CurrentFrameIsLast && !CurrentAnimation.Looping) return;
//            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
//            if(elapsedTime > CurrentAnimation.FrameDuration)
//            {
//                elapsedTime -= CurrentAnimation.FrameDuration;

//                CurrentAnimation.NextFrame();
//                iAnimationRenderUpdate.SetTexture2D(CurrentAnimation.CurrentTexture);

//            }
//            base.Update(gameTime);
//        }



//    }
//}
