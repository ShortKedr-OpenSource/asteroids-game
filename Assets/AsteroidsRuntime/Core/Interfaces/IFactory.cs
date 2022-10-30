namespace Asteroids.Core.Interfaces
{
    public interface IFactory<in TParams, out TResult>
    {
        public TResult Create(TParams parameters);
    }
}