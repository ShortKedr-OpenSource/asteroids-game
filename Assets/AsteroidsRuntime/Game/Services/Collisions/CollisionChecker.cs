using System.Runtime.CompilerServices;

namespace Asteroids.Math.Collisions
{
    public static class CollisionChecker
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCircleCollision(ICircleCollidable first, ICircleCollidable second)
        {
            return (first.CurrentPosition - second.CurrentPosition).magnitude <=
                   first.CurrentRadius + second.CurrentRadius;
        }
    }
}