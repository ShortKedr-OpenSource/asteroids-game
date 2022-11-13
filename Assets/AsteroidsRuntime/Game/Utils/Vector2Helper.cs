using UnityEngine;

namespace Asteroids.Game.Utils
{
    public static class Vector2Helper
    {
        /// <summary>
        /// Generates random point in rect range
        /// </summary>
        /// <param name="min">min coords</param>
        /// <param name="max">max coords</param>
        /// <param name="precision">random operation precision</param>
        /// <returns>random point for passed properties</returns>
        public static Vector2 Random(Vector2 min, Vector2 max, float precision = 1000f)
        {
            return new Vector2()
            {
                x = UnityEngine.Random.Range(min.x * precision, max.x * precision) / precision,
                y = UnityEngine.Random.Range(min.y * precision, max.y * precision) / precision
            };
        }

        /// <summary>
        /// Generate random point in radial range around point
        /// </summary>
        /// <param name="center">center point</param>
        /// <param name="minRadius">min distance from center</param>
        /// <param name="maxRadius">max distance from center</param>
        /// <param name="minAngle">min angle</param>
        /// <param name="maxAngle">max angle</param>
        /// <param name="precision">float value random precision</param>
        /// <returns>random point for passed properties</returns>
        public static Vector2 RandomRadial(Vector2 center, float minRadius, float maxRadius, 
            float minAngle = 0, float maxAngle = 360, float precision = 1000f)
        {
            float randomAngle = UnityEngine.Random.Range(minAngle * precision, maxAngle * precision) / precision;
            float randomRadius = UnityEngine.Random.Range(minRadius * precision, maxRadius * precision) / precision;

            float radians = randomAngle * Mathf.Deg2Rad;

            return new Vector2()
            {
                x = Mathf.Cos(radians) * randomRadius,
                y = Mathf.Sin(radians) * randomRadius,
            };
        }
    }
}