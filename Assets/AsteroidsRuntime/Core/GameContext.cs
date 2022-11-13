using System.Collections.Generic;
using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Core
{
    public abstract class GameContext : MonoBehaviour
    {
        private LifeCycleContainer _container = new LifeCycleContainer();

        private bool _wasInitialized = false;
        
        private void Start()
        {
            StartGameContext();
            var initializables = _container.Initializables.ToArray();
            foreach (var t in initializables)
            {
                t.Initialize();
            }

            _wasInitialized = true;
        }

        private void Update()
        {
            var tickables = _container.Tickables.ToArray();
            foreach (var t in tickables)
            {
                t.Tick();
            }
        }

        private void LateUpdate()
        {
            var lateTickables = _container.LateTickables;
            foreach (var t in lateTickables)
            {
                t.LateTick();
            }
        }

        private void OnDestroy()
        {
            var disposables = _container.Disposables;

            for (var i = disposables.Count - 1; i >= 0; i--)
            {
                disposables[i].Dispose();
            }
        }

        public void Bind(object obj)
        {
            _container.Bind(obj);
            OnBind(obj);
            
            if (!_wasInitialized) return;
            if (obj is IInitializable initializable) initializable.Initialize();
        }

        public void Unbind(object obj)
        {
            _container.Unbind(obj);
            OnUnbind(obj);
            //TODO implement dispose
        }

        public T FindObject<T>()
        {
            return _container.GetObject<T>();
        }
        
        public T[] FindObjects<T>()
        {
            return _container.GetObjects<T>();
        }

        protected virtual void OnBind(object obj)
        {
            
        }

        protected virtual void OnUnbind(object obj)
        {
            
        }
        
        protected abstract void StartGameContext();
    }
}