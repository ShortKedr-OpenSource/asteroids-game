using Asteroids.Math.Collisions.Collidables;
using UnityEngine;

namespace Asteroids.Math.Collisions.Shapes
{
    public struct Ray : IRayCollidable
    {
        public Vector2 Origin;
        public Vector2 Direction;
        public float Thickness;

        public Ray(Vector2 origin, Vector2 direction, float thickness)
        {
            Origin = origin;
            Direction = direction;
            Thickness = thickness;
        }

        Vector2 IRayCollidable.Origin => Origin;
        Vector2 IRayCollidable.Direction => Direction;
        float IRayCollidable.Thickness => Thickness;
    }
}