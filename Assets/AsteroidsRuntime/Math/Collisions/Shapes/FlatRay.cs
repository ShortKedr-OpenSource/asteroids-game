using UnityEngine;

namespace Asteroids.Math.Collisions.Shapes
{

    public struct FlatRay
    {
        public Vector2 Origin;
        public Vector2 Direction;

        public FlatRay(Vector2 origin, Vector2 direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }

}