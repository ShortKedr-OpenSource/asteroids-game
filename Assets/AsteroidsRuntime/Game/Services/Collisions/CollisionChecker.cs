using System;
using System.Runtime.CompilerServices;
using Asteroids.Math.Collisions.Collidables;

namespace Asteroids.Math.Collisions
{
    public static class CollisionChecker
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
            return CollisionMath.CheckCollision(first, second);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(ICircleCollidable first, IRayCollidable second)
        {
            return CollisionMath.CheckCollision(first, second);
        }
    }
}