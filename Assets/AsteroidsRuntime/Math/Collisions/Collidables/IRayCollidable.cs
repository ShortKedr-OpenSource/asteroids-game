using UnityEngine;

namespace Asteroids.Math.Collisions.Collidables
{

    public interface IRayCollidable : ICollidable
    {
        public Vector2 Origin { get; }
        public Vector2 Direction { get; }
        public float Thickness { get; }
    }

}