using Asteroids.Game.Configs;
using Asteroids.Core;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Models;
using Asteroids.Game.Presenters;
using Asteroids.Game.Views;
using UnityEngine;

namespace Asteroids.Game.Factories
{
    public class ShipFactory : IContextFactory<ShipFactoryParams, ShipPresenter>
    {

        public ShipPresenter Create(ShipFactoryParams p)
        {
            var config = p.ShipConfig;

            ShipModel model = new ShipModel(p.ShipConfig, p.BulletConfig, p.LaserConfig)
            {
                Position = p.Position,
                Rotation = p.Rotation
            };
            
            ShipView view = Object.Instantiate(config.ViewPrefab);

            ShipPresenter presenter = new ShipPresenter(model, view, p.Context);
            return presenter;
        }
    }

    public struct ShipFactoryParams
    {
        public GameContext Context;
        public ShipConfig ShipConfig;
        public BulletConfig BulletConfig;
        public LaserConfig LaserConfig;
        public Vector2 Position;
        public float Rotation;
    }
}