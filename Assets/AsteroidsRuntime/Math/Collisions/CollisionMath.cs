using System.Runtime.CompilerServices;
using Asteroids.Math.Collisions.Collidables;
using Asteroids.Math.Collisions.Shapes;
using UnityEngine;

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
            Vector2 origin = second.Origin;
            Vector2 direction = second.Direction;
            Vector2 normal = new Vector2(-direction.y, direction.x).normalized;
            float halfThickness = second.Thickness / 2f;
            
            Vector2 originLeft = origin + normal * halfThickness;
            Vector2 originRight = origin - normal * halfThickness;

            FlatRay leftRay = new FlatRay(originLeft, direction);
            FlatRay rightRay = new FlatRay(originRight, direction);
                
            FlatRay circleLeftRay = new FlatRay(first.Position, normal * first.Radius);
            FlatRay circleRightRay = new FlatRay(first.Position, -normal * first.Radius);

            bool intersectionOne = RayMath.FlatRayIntersection(leftRay, circleRightRay, out var p1);
            bool intersectionTwo = RayMath.FlatRayIntersection(rightRay, circleLeftRay, out var p2);

            return intersectionTwo || intersectionOne;
        }
    }

}