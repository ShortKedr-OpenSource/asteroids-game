
using UnityEngine;

namespace Asteroids.Math.Collisions.Collidables
{
    public interface ICircleCollidable : ICollidable
    {
        public Vector2 Position { get; }
        public float Radius { get; }
    }
}