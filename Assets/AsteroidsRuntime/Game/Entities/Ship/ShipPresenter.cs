using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Game.Entities.Asteroid;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.CameraPortal;
using Asteroids.Game.Entities.Laser;
using Asteroids.Game.Utils;
using Asteroids.Math.Collisions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Entities.Ship
{
    public class ShipPresenter : ContextPresenter<ShipModel, ShipView>,
        IInitializable, ITickable, ICircleCollidable
    {
        private BulletFactory _bulletFactory;
        private LaserFactory _laserFactory;
        private CameraPortalModel _cameraPortalModel;

        public ShipPresenter(ShipModel model, ShipView view, GameContext context)
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            _cameraPortalModel = Context.FindObject<CameraPortalModel>();
            _bulletFactory = Context.FindService<BulletFactory>();
            _laserFactory = Context.FindService<LaserFactory>();
        }

        void ITickable.Tick()
        {
            ProcessInput();
            ProcessMovement();
            ProcessCameraPortal();
            UpdateView();
        }

        private void ProcessInput()
        {
            var shipConfig = Model.ShipConfig;
            
            //TODO rework to InputSystem;
            
            if (Input.GetKey(KeyCode.A)) Model.Rotation += shipConfig.TurnSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)) Model.Rotation -= shipConfig.TurnSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
            {
                Vector2 speedIncrement = MathHelper.RotationToVector(Model.Rotation) * shipConfig.SpeedIncrement;
                Model.Speed += speedIncrement * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _bulletFactory.Create(new BulletFactoryParams()
                {
                    Config = Model.BulletConfig,
                    Context = Context,
                    Direction = Model.Rotation,
                    Position = Model.Position,
                });
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Bounds portalBounds = _cameraPortalModel.GetCameraPortalBounds();
                float rayLength = Mathf.Sqrt(portalBounds.size.x * portalBounds.size.x +
                                             portalBounds.size.y * portalBounds.size.y);
                
                // TODO if can shoot laser => shot laser and decrease ammo acount;
                
                _laserFactory.Create(new LaserFactoryParams()
                {
                    Config = Model.LaserConfig,
                    Context = Context,
                    Direction = Model.Rotation,
                    Origin = Model.Position,
                    Length = rayLength,
                });
            }
        }

        private void ProcessMovement()
        {
            var shipConfig = Model.ShipConfig;
            
            Model.Position += Model.Speed * Time.deltaTime;
            Model.Speed -= Model.Speed.normalized * (shipConfig.Friction * Time.deltaTime);
            if (Model.Speed.magnitude > shipConfig.MaxSpeed) Model.Speed = Model.Speed.normalized * shipConfig.MaxSpeed;
        }
        
        private void ProcessCameraPortal()
        {
            Vector2 currentPosition = Model.Position;
            float sizeRadius = Model.ShipConfig.SizeRadius;
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
            View.SetRotation(Model.Rotation);
        }
        
        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }

        public Vector2 CurrentPosition => Model.Position;
        public float CurrentRadius => Model.ShipConfig.SizeRadius;

        public void OnCollisionHappen(ICircleCollidable with)
        {
            if (with is AsteroidPresenter) Dispose();
        }
    }
}