using System;

namespace Asteroids.Core.Abstract
{
    public abstract class ContextPresenter<TModel, TView> : IDisposable
    {
        protected TModel Model { get; }
        protected TView View { get; }
        protected GameContext Context { get; }

        public ContextPresenter(TModel model, TView view, GameContext context)
        {
            Model = model;
            View = view;
            Context = context;
            
            context.Bind(this);
            context.Bind(Model);
            context.Bind(View);
        }

        public virtual void Dispose()
        {
            Context.Unbind(this);
            Context.Unbind(Model);
            Context.Unbind(View);
        }
    }
}