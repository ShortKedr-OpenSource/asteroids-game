using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Game.Models;
using Asteroids.Game.Views;
using Asteroids.Core.Interfaces;
using UnityEngine;

namespace Asteroids.Game.Presenters
{
    public class AsteroidPresenter : ContextPresenter<AsteroidModel, AsteroidView>,
        IInitializable, ITickable
    {
        
        public AsteroidPresenter(AsteroidModel model, AsteroidView view, GameContext context)
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            
        }

        void ITickable.Tick()
        {
            Model.Position += Model.Speed * Time.deltaTime;

            if (Model.ModelChanged)
            {
                View.SetPosition(Model.Position);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }
    }
}