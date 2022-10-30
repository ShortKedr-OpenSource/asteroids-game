using Asteroids.Core;
using Asteroids.Game.Editor.Debug;
using Asteroids.Game.Utils;
using Asteroids.Game.Entities.Asteroid;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.CameraPortal;
using Asteroids.Game.Entities.Laser;
using Asteroids.Game.Entities.Saucer;
using Asteroids.Game.Entities.Ship;
using Asteroids.Math.Collisions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Game
{
    public class AsteroidsGameContext : GameContext
    {
        [Header("Ship Setup")]
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private LaserConfig _laserConfig;
        
        [Header("Hostiles Setup")]
        [SerializeField] private SaucerConfig[] _saucerConfigs;
        [SerializeField] private AsteroidConfig[] _asteroidConfigs;
        
        [Header("Game Setup")]
        [SerializeField] private Camera _gameCamera;

        [Header("Debug")] 
        [SerializeField] private bool debugObjectSizes = true;
        
        private readonly ShipFactory _shipFactory = new ShipFactory();
        private readonly SaucerFactory _saucerFactory = new SaucerFactory();
        private readonly AsteroidFactory _asteroidFactory = new AsteroidFactory();
        private readonly BulletFactory _bulletFactory = new BulletFactory();
        private readonly LaserFactory _laserFactory = new LaserFactory();

        private readonly CollisionService _collisionService = new CollisionService();
        
        private DebugContextObjectSizes _sizesGizmoDrawer;

        protected override void StartGameContext()
        {
            Bind(_collisionService);
            
            ShipPresenter ship = _shipFactory.Create(new ShipFactoryParams()
            {
                ShipConfig = _shipConfig, 
                BulletConfig = _bulletConfig,
                LaserConfig = _laserConfig,
                Position = Vector2.zero, 
                Rotation = Random.Range(0, 360f), 
                Context = this,
            });

            for (int i = 0; i < 5; i++)
            {
                AsteroidConfig config = _asteroidConfigs[Random.Range(0, _asteroidConfigs.Length)];
                AsteroidPresenter asteroidPresenter = _asteroidFactory.Create(new AsteroidFactoryParams()
                {
                    Context = this,
                    Config = config,
                    Position = Vector2Helper.Random(new Vector2(-5, -5), new Vector2(5, 5))
                });
            }
            
            CameraPortalModel cameraPortalModel = new CameraPortalModel();
            cameraPortalModel.SetCamera(_gameCamera);
            Bind(cameraPortalModel);
            
            Debug.Log(_collisionService.CircleCollidables.Count);
        }

        protected override void OnBind(object obj)
        {
            _collisionService.Add(obj);
        }

        protected override void OnUnbind(object obj)
        {
            _collisionService.Remove(obj);
        }

        public void OnRenderObject()
        {
            if (_sizesGizmoDrawer == null) _sizesGizmoDrawer = new DebugContextObjectSizes(this);
            if (debugObjectSizes) _sizesGizmoDrawer.DebugDrawSizesGizmo();
        }
        
    }
}