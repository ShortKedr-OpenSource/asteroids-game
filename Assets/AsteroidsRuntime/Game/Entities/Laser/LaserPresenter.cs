using System;
using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Math.Collisions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserPresenter : ContextPresenter<LaserModel, LaserView>,
        IInitializable, ITickable, IRayCollidable
    {

        private float _timer;

        Vector2 IRayCollidable.Origin => Model.Origin;
        float IRayCollidable.Length => Model.Length;
        float IRayCollidable.Thickness => Model.Config.Thickness;

        public LaserPresenter(LaserModel model, LaserView view, GameContext context)
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            UpdateView();
            _timer = 0f;
        }

        void ITickable.Tick()
        {
            if (_timer >= Model.Config.LifeTime) Dispose();
            _timer += Time.deltaTime;
            
            if (Model.ModelChanged) UpdateView();
        }

        private void UpdateView()
        {
            View.SetPosition(Model.Origin);
            View.SetDirection(Model.Direction);
            View.SetLength(Model.Length);
        }
        
        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }

        public void OnCollisionHappen(ICircleCollidable with)
        {
            throw new NotImplementedException();
        }
    }
}