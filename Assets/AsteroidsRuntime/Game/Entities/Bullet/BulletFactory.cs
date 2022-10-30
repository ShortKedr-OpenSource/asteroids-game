using Asteroids.Core;
using Asteroids.Core.Interfaces;
using UnityEngine;

namespace Asteroids.Game.Entities.Bullet
{
    public class BulletFactory : IFactory<BulletFactoryParams, BulletPresenter>
    {
        public BulletPresenter Create(BulletFactoryParams p)
        {
            var config = p.Config;

            BulletModel model = new BulletModel(config, p.Direction);
            model.Position = p.Position;

            BulletView view = Object.Instantiate(config.ViewPrefab);
            view.SetPosition(p.Position);
            view.SetRotation(p.Direction);

            BulletPresenter presenter = new BulletPresenter(model, view, p.Context);

            return presenter;
        }
    }

    public struct BulletFactoryParams
    {
        public GameContext Context;
        public BulletConfig Config;
        public Vector2 Position;
        public float Direction;
    }
}