using System;

namespace ECS.Core.Util.Extensions
{
    public static class NumberInterpolationExtensions
    {
        public static float Linear(float elapsed, float limit = 1)
        {
            return elapsed / limit;
        }


        public static float EaseOutQuad(float elapsed, float limit = 1)
        {
            float release = elapsed / limit;
            return (1 - (1 - release) * (1 - release));
        }


        //TODO: SmoothDamp ?
        public static float EaseInOutQuad(float elapsed, float limit = 1)
        {
            float released = elapsed / limit;
            return released < 0.5 ? 2 * released * released : 1 - MathF.Pow(-2 * released + 2, 2) / 2;
        }


        // public static float ParametricBlend(float elapsed, float limit = 1)
        // {
        //     float released = elapsed / limit;
        //     float sqrt = released * released;
        //     return sqrt / (2.0f * (sqrt - released) + 1.0f);

        // }

        public static float EaseOutElastic(float elapsed, float limit = 1)
        {
            float release = elapsed / limit;
            return MathF.Sin(-13 * (release + 1) * (MathF.PI / 2)) * MathF.Pow(2f, -10f * release) + 1;
        }



        //TODO: Fix it
        public static float Bounce(float elapsed, float limit = 1)
        {
            float released = elapsed / limit;

            const float n1 = 7.5625f;
            const float d1 = 2.75f;
            if (released < 1.0f / d1)
            {
                return n1 * released * released;
            }
            else if (released < 2.0f / d1)
            {
                released -= 1.5f * d1;
                return n1 * released * released + 0.75f;
            }
            else if (released < 2.5f / d1)
            {
                released -= 2f / d1;
                return n1 * released * released + 0.9375f;
            }
            else
            {
                released -= 2.625f / d1;
                return n1 * released * released + 0.984375f;
            }

        }


    }
}
