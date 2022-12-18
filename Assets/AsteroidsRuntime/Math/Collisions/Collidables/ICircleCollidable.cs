
using UnityEngine;

namespace Asteroids.Math.Collisions.Collidables
{
    public interface ICircleCollidable : ICollidable<ICircleCollidable>, ICollidable<IRayCollidable>
    {
        public Vector2 Position { get; }
        public float Radius { get; }
    }
}