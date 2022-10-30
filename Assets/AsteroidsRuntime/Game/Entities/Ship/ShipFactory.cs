using Asteroids.Core;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.Laser;
using UnityEngine;

namespace Asteroids.Game.Entities.Ship
{
    public class ShipFactory : IFactory<ShipFactoryParams, ShipPresenter>
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
            view.SetPosition(p.Position);
            view.SetRotation(p.Rotation);

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