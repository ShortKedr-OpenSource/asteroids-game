using Asteroids.Core;
using Asteroids.Core.Interfaces;
using UnityEngine;

namespace Asteroids.Game.Entities.Asteroid
{
    public class AsteroidFactory : IFactory<AsteroidFactoryParams, AsteroidPresenter>
    {
        public AsteroidPresenter Create(AsteroidFactoryParams p)
        {
            var config = p.Config;
            float speed = Random.Range(config.MinSpeed / 1000f, config.MaxSpeed / 1000f) * 1000f;
            float speedRadians = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            AsteroidModel model = new AsteroidModel(config, config.GetRandomSeparationConfigs())
            {
                Position = p.Position,
                Speed = new Vector2()
                {
                    x = Mathf.Cos(speedRadians) * speed,
                    y = Mathf.Sin(speedRadians) * speed,
                }
            };
            
            AsteroidView view = Object.Instantiate(config.ViewPrefab);
            view.SetPosition(p.Position);
            view.SetRotation(Random.Range(0f, 360f));

            AsteroidPresenter presenter = new AsteroidPresenter(model, view, p.Context);
            
            return presenter;
        }
    }

    public struct AsteroidFactoryParams
    {
        public GameContext Context;
        public AsteroidConfig Config;
        public Vector2 Position;
    }
}