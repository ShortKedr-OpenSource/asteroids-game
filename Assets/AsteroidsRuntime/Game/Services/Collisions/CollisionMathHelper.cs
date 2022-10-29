namespace Asteroids.Math.Collisions
{
    public static class CollisionChecker
    {
        public static bool CheckCircleCollision(ICircleCollidable first, ICircleCollidable second)
        {
            return (first.CurrentPosition - second.CurrentPosition).magnitude <=
                   first.CurrentRadius + second.CurrentRadius;
        }
    }
}