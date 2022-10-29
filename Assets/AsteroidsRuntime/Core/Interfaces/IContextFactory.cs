namespace Asteroids.Core.Interfaces
{
    public interface IContextFactory<in TParams, out TResult>
    {
        public TResult Create(TParams parameters);
    }
}