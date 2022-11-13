using System.Collections;
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
        [SerializeField] private float _asteroidSpawnRadius = 4f;
        
        [Header("Debug")] 
        [SerializeField] private bool debugObjectSizes = true;

        private readonly CollisionService _collisionService = new();

        private readonly ShipFactory _shipFactory = new();
        private readonly SaucerFactory _saucerFactory = new();
        private readonly AsteroidFactory _asteroidFactory = new();
        private readonly BulletFactory _bulletFactory = new();
        private readonly LaserFactory _laserFactory = new();
        
        private DebugContextObjectSizes _sizesGizmoDrawer;
        private Coroutine _saucerSpawnCoroutine;

        protected override void StartGameContext()
        {
            BindService(_collisionService);
            
            BindService(_shipFactory);
            BindService(_saucerFactory);
            BindService(_asteroidFactory);
            BindService(_bulletFactory);
            BindService(_laserFactory);
            
            CameraPortalModel cameraPortalModel = new CameraPortalModel();
            cameraPortalModel.SetCamera(_gameCamera);
            Bind(cameraPortalModel);

            var cameraBounds = cameraPortalModel.GetCameraPortalBounds();
            
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
                    Position = Vector2Helper.RandomRadial(Vector2.zero, _asteroidSpawnRadius, 
                        Mathf.Max(cameraBounds.size.x, cameraBounds.size.y))
                });
            }

            Bind(_asteroidFactory); // TODO refactor to BindFactory

            _saucerSpawnCoroutine = StartCoroutine(SaucerSpawnCoroutine());
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

        IEnumerator SaucerSpawnCoroutine()
        {
            while (gameObject != null)
            {
                yield return new WaitForSeconds(5f); //TODO implement;
            }
        }
        
        
    }
}