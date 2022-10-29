using Asteroids.Game.Configs;
using Asteroids.Core;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Presenters;

namespace Asteroids.Game.Factories
{
    public class SaucerFactory : IContextFactory<SaucerFactoryParams, SaucerPresenter>
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