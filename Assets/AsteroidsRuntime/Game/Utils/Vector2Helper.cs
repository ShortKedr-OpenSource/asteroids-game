using UnityEngine;

namespace Asteroids.Game.Utils
{
    public static class Vector2Helper
    {
        public static Vector2 Random(Vector2 min, Vector2 max, float per = 1000f)
        {
            return new Vector2()
            {
                x = UnityEngine.Random.Range(min.x * per, max.x * per) / per,
                y = UnityEngine.Random.Range(min.y * per, max.y * per) / per
            };
        }
    }
}