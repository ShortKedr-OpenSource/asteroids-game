
using UnityEngine;

namespace Asteroids.Math.Collisions
{
    public interface ICircleCollidable
    {
        public Vector2 CurrentPosition { get; }
        public float CurrentRadius { get; }
    }
}