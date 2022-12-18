using Asteroids.Math.Collisions.Collidables;
using UnityEngine;

namespace Asteroids.Math.Collisions.Shapes
{

    public struct Circle : ICircleCollidable
    {
        public Vector2 Position;
        public float Radius;

        public Circle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        Vector2 ICircleCollidable.Position => Position;
        float ICircleCollidable.Radius => Radius;
    }

}