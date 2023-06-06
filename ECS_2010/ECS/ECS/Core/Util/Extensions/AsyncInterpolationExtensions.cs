//using ECS.Core.Components;
//using ECS.Core.Managers;
//using Microsoft.Xna.Framework;
//using System.Diagnostics;
//using System.Threading.Tasks;

//namespace ECS.Core.Util.Extensions
//{
//    public static class AsyncInterpolationExtensions
//    {

//        public static async Task EaseOutScale(this Transform transform, Vector3 scale, float interval = 1)
//        {

//            Vector3 start = transform.Scale;
//            float elapsedTime = 0;

//            while (elapsedTime < interval)
//            {
//                float t = NumberInterpolationExtensions.EaseOutQuad(elapsedTime, interval);
//                transform.SetScale(Vector3.Lerp(start, scale, t));

//                double deltaTime = Time.Instance.ElapsedTime;

//                elapsedTime += (float)deltaTime;
//                await Task.Delay((int)deltaTime);

//            }

//            transform.SetScale(scale);
//        }
//        public static async Task EaseOutPosition(this Transform transform, Vector3 targetPosition, float interval = 1)
//        {

//            Vector3 start = transform.Translation;
//            float elapsedTime = 0;

//            while (elapsedTime < interval)
//            {
//                float t = NumberInterpolationExtensions.EaseOutQuad(elapsedTime, interval);
//                transform.Translate(Vector3.Lerp(start, targetPosition, t));

//                float deltaTime = Time.Instance.ElapsedTime;
//                elapsedTime += (float)deltaTime;
//                await Task.Delay((int)deltaTime);
//            }

//            transform.SetTranslation(targetPosition);
//        }





//    }
//}
