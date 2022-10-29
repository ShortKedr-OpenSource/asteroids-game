using Asteroids.Core;
using Asteroids.Game.Configs;
using Asteroids.Game.Editor.Debug;
using Asteroids.Game.Factories;
using Asteroids.Game.Presenters;
using Asteroids.Game.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Game
{
    public class AsteroidsGameContext : GameContext
    {
        [Header("Setup")]
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private SaucerConfig[] _saucerConfigs;
        [SerializeField] private AsteroidConfig[] _asteroidConfigs;

        [Header("Debug")] 
        [SerializeField] private bool debugObjectSizes = true;
        
        private readonly ShipFactory _shipFactory = new ShipFactory();
        private readonly SaucerFactory _saucerFactory = new SaucerFactory();
        private readonly AsteroidFactory _asteroidFactory = new AsteroidFactory();
        private readonly BulletFactory _bulletFactory = new BulletFactory();
        private readonly LaserFactory _laserFactory = new LaserFactory();
        
        private DebugContextObjectSizes _sizesGizmoDrawer;

        protected override void StartGameContext()
        {
            ShipPresenter ship = _shipFactory.Create(new ShipFactoryParams()
                {ShipConfig = _shipConfig, Position = Vector2.zero, Rotation = Random.Range(0, 360f), Context = this});

            for (int i = 0; i < 5; i++)
            {
                var config = _asteroidConfigs[Random.Range(0, _asteroidConfigs.Length)];
                var asteroid = _asteroidFactory.Create(new AsteroidFactoryParams()
                {
                    Context = this,
                    Config = config,
                    Position = Vector2Helper.Random(new Vector2(-5, -5), new Vector2(5, 5))
                });
            }
        }

        public void OnRenderObject()
        {
            if (_sizesGizmoDrawer == null) _sizesGizmoDrawer = new DebugContextObjectSizes(this);
            if (debugObjectSizes) _sizesGizmoDrawer.DebugDrawSizesGizmo();
        }
        
    }
}