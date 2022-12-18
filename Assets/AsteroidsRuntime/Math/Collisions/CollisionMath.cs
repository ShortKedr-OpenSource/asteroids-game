using System;
using System.Runtime.CompilerServices;
using Asteroids.Math.Collisions.Collidables;
using UnityEngine;
using Ray = Asteroids.Math.Collisions.Shapes.Ray;

namespace Asteroids.Math.Collisions
{

    public static class CollisionMath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(ICircleCollidable first, ICircleCollidable second)
        {
            return (first.Position - second.Position).magnitude <=
                   first.Radius + second.Radius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(IRayCollidable first, IRayCollidable second)
        {
            return RayMath.RayIntersection(first, second, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(ICircleCollidable first, IRayCollidable second)
        {
            Ray normalRay = default; // TODO implement;
            return RayMath.RayIntersection(normalRay, second, out _);
        }
    }

}