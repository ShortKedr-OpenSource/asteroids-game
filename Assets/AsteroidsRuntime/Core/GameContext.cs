using System;
using UnityEngine;

namespace Asteroids.Core
{
    public abstract class GameContext : MonoBehaviour
    {
        private LifeCycleContainer _container = new LifeCycleContainer();

        private void Start()
        {
            StartGameContext();
            var initializables = _container.Initializables;
            foreach (var t in initializables)
            {
                t.Initialize();
            }
        }

        private void Update()
        {
            var tickables = _container.Tickables;
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
        }

        public void Unbind(object obj)
        {
            _container.Unbind(obj);
        }

        public T FindObject<T>()
        {
            return _container.GetObject<T>();
        }
        
        public T[] FindObjects<T>()
        {
            return _container.GetObjects<T>();
        }

        protected abstract void StartGameContext();
    }
}