using Asteroids.Core.Interfaces;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserFactory : IFactory<LaserFactoryParams, LaserPresenter>
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