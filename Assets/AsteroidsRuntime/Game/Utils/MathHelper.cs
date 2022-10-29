using UnityEngine;

namespace Asteroids.Game.Utils
{
    public static class MathUtil
    {
        public static Vector2 RotationToVector(float rotationDegree)
        {
            float rads = rotationDegree * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
        }
    }
}