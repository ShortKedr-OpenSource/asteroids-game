using UnityEngine;

namespace Asteroids.Math.Collisions
{

    public interface IRayCollidable : ICollidable<ICircleCollidable>, ICollidable<IRayCollidable>
    {
        public Vector2 Origin { get; }
        public float Length { get; }
        public float Thickness { get; }
    }

}