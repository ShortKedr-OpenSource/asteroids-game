using Asteroids.Core.Interfaces;

namespace Asteroids.Game.Entities.Saucer
{
    public class SaucerFactory : IFactory<SaucerFactoryParams, SaucerPresenter>
    {
        public SaucerPresenter Create(SaucerFactoryParams parameters)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct SaucerFactoryParams
    {
        public SaucerConfig Config;
    }
}