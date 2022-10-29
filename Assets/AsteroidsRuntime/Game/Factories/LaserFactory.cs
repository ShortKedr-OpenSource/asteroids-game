using Asteroids.Core;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Configs;
using Asteroids.Game.Presenters;

namespace Asteroids.Game.Factories
{
    public class LaserFactory : IContextFactory<LaserFactoryParams, LaserPresenter>
    {
        public LaserPresenter Create(LaserFactoryParams parameters)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct LaserFactoryParams
    {
        private LaserConfig Config;
    }
}