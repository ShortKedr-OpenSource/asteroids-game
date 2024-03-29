using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Game.Entities.Asteroid;
using Asteroids.Game.Entities.CameraPortal;
using Asteroids.Game.Entities.Ship;
using Asteroids.Math.Collisions;
using Asteroids.Math.Collisions.Collidables;
using UnityEngine;

namespace Asteroids.Game.Entities.Bullet
{
    public class BulletPresenter : ContextPresenter<BulletModel, BulletView>,
        ITickable, IInitializable, ICircleCollidable
    {

        private CameraPortalModel _cameraPortalModel;

        Vector2 ICircleCollidable.Position => Model.Position;
        float ICircleCollidable.Radius => Model.Config.SizeRadius;
        
        
        public BulletPresenter(BulletModel model, BulletView view, GameContext context) 
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            _cameraPortalModel = Context.FindObject<CameraPortalModel>();
            View.SetRotation(Model.Direction);
        }
        
        void ITickable.Tick()
        {
            Model.Position += Model.Speed * Time.deltaTime;

            ProcessCameraPortal();
            
            if (Model.ModelChanged) UpdateView();
        }
        
        private void ProcessCameraPortal()
        {
            Vector2 currentPosition = Model.Position;
            float sizeRadius = Model.Config.SizeRadius;
            Bounds portalBounds = _cameraPortalModel.GetCameraPortalBounds();
            
            if (currentPosition.x < portalBounds.min.x - sizeRadius) Dispose();
            if (currentPosition.x > portalBounds.max.x + sizeRadius) Dispose();
            if (currentPosition.y < portalBounds.min.y - sizeRadius) Dispose();
            if (currentPosition.y > portalBounds.max.y + sizeRadius) Dispose();
        }

        private void UpdateView()
        {
            View.SetPosition(Model.Position);
        }
        
        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }
        
        public void OnCollisionHappen(ICollidable with)
        {
            if (with is ShipPresenter) return;
            if (with is BulletPresenter) return;
            Dispose();
        }
    }
}