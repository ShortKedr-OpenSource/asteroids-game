using Asteroids.Core;
using Asteroids.Game.Configs;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Presenters;

namespace Asteroids.Game.Factories
{
    public class BulletFactory : IContextFactory<BulletFactoryParams, BulletPresenter>
    {
        public BulletPresenter Create(BulletFactoryParams parameters)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct BulletFactoryParams
    {
        public BulletConfig Config;
    }
}