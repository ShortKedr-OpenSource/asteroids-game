namespace Asteroids.Math.Collisions
{

    public interface ICollidable
    {
        public void OnCollisionHappen(ICollidable with){}
    }

    public interface ICollidable<in T> : ICollidable where T : ICollidable
    {
        public void OnCollisionHappen(T with){}
    }

}