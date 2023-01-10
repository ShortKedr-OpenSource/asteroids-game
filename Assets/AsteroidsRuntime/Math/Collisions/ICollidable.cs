namespace Asteroids.Math.Collisions
{

    public interface ICollidable
    {
        public void OnCollisionHappen(ICollidable with);
    }
}