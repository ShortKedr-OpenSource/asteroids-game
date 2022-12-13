using System;
using System.Runtime.CompilerServices;

namespace Asteroids.Math.Collisions
{
    public static class CollisionChecker
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(ICircleCollidable first, ICircleCollidable second)
        {
            return (first.CurrentPosition - second.CurrentPosition).magnitude <=
                   first.CurrentRadius + second.CurrentRadius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(IRayCollidable first, IRayCollidable second)
        {
            throw new NotImplementedException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCollision(ICircleCollidable first, IRayCollidable second)
        {
            throw new NotImplementedException();
        }
    }
}