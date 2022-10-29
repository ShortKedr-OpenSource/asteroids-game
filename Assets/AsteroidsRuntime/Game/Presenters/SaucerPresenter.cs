using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Game.Models;
using Asteroids.Game.Views;
using Asteroids.Core.Interfaces;
using UnityEngine;

namespace Asteroids.Game.Presenters
{
    public class SaucerPresenter : ContextPresenter<SaucerModel, SaucerView>, 
        IInitializable, ITickable
    {

        public SaucerPresenter(SaucerModel model, SaucerView view, GameContext context) 
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