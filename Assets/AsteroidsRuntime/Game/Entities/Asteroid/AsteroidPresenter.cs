using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.CameraPortal;
using Asteroids.Math.Collisions;
using Asteroids.Math.Collisions.Collidables;
using UnityEngine;

namespace Asteroids.Game.Entities.Asteroid
{
    public class AsteroidPresenter : ContextPresenter<AsteroidModel, AsteroidView>,
        IInitializable, ITickable, ICircleCollidable
    {
        private CameraPortalModel _cameraPortalModel;
        private AsteroidFactory _asteroidFactory;

        public AsteroidPresenter(AsteroidModel model, AsteroidView view, GameContext context)
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            _cameraPortalModel = Context.FindObject<CameraPortalModel>();
            _asteroidFactory = Context.FindService<AsteroidFactory>();
        }

        void ITickable.Tick()
        {
            Model.Position += Model.Speed * Time.deltaTime;
            ProcessCameraPortal();
            UpdateView();
        }

        private void ProcessCameraPortal()
        {
            Vector2 currentPosition = Model.Position;
            float sizeRadius = Model.Config.SizeRadius;
            Bounds portalBounds = _cameraPortalModel.GetCameraPortalBounds();

            if (currentPosition.x < portalBounds.min.x - sizeRadius)
            {
                Model.Position = new Vector2(portalBounds.max.x + sizeRadius, currentPosition.y);
            }

            if (currentPosition.x > portalBounds.max.x + sizeRadius)
            {
                Model.Position = new Vector2(portalBounds.min.x - sizeRadius, currentPosition.y);
            }

            if (currentPosition.y < portalBounds.min.y - sizeRadius)
            {
                Model.Position = new Vector2(currentPosition.x, portalBounds.max.y + sizeRadius);
            }

            if (currentPosition.y > portalBounds.max.y + sizeRadius)
            {
                Model.Position = new Vector2(currentPosition.x, portalBounds.min.y - sizeRadius);
            }
        }

        private void UpdateView()
        {
            if (!Model.ModelChanged) return;
            View.SetPosition(Model.Position);
        }

        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }

        public Vector2 Position => Model.Position;
        public float Radius => Model.Config.SizeRadius;

        public void OnCollisionHappen(ICircleCollidable with)
        {
            if (with is BulletPresenter bullet)
            {
                var separationConfigs = Model.SeparationConfigs;
                for (int i = 0; i < separationConfigs.Length; i++)
                {
                    _asteroidFactory.Create(new AsteroidFactoryParams()
                    {
                        Config = separationConfigs[i],
                        Context = Context,
                        Position = Model.Position,
                    });
                }

                Dispose();
            }
        }
    }
}