using Asteroids.Core;
using Asteroids.Core.Interfaces;
using UnityEngine;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserFactory : IFactory<LaserFactoryParams, LaserPresenter>
    {
        public LaserPresenter Create(LaserFactoryParams p)
        {
            var config = p.Config;
            
            LaserModel model = new LaserModel(config);
            model.Origin = p.Origin;
            model.Direction = p.Direction;
            model.Length = p.Length;

            LaserView view = Object.Instantiate(config.ViewPrefab);

            LaserPresenter presenter = new LaserPresenter(model, view, p.Context);

            return presenter;
        }
    }

    public struct LaserFactoryParams
    {
        public GameContext Context;
        public LaserConfig Config;
        public Vector2 Origin;
        public float Direction;
        public float Length;
    }
}