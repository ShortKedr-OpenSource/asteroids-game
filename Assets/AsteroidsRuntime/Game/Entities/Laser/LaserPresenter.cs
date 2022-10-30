using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserPresenter : ContextPresenter<LaserModel, LaserView>,
        IInitializable, ITickable
    {
        public LaserPresenter(LaserModel model, LaserView view, GameContext context)
            : base(model, view, context)
        {
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }
    }
}