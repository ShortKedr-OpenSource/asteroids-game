
using UnityEngine;

namespace Asteroids.Math.Collisions
{
    public interface ICircleCollidable : ICollidable<ICircleCollidable>, ICollidable<IRayCollidable>
    {
        public Vector2 CurrentPosition { get; }
        public float CurrentRadius { get; }
    }
}