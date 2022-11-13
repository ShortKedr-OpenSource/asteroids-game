using System.Linq;
using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Core
{
    public abstract class GameContext : MonoBehaviour
    {
        private readonly LifeCycleContainer _objectContainer = new();
        private readonly LifeCycleContainer _serviceContainer = new();

        private bool _wasInitialized = false;
        
        private void Start()
        {
            StartGameContext();
            
            var serviceInitializables = _objectContainer.Initializables.ToArray();
            foreach (var t in serviceInitializables) t.Initialize();
            
            var objectInitializables = _objectContainer.Initializables.ToArray();
            foreach (var t in objectInitializables) t.Initialize();

            _wasInitialized = true;
        }

        private void Update()
        {
            var serviceTickables = _serviceContainer.Tickables.ToArray();
            foreach (var t in serviceTickables) t.Tick();
            
            var objectTickables = _objectContainer.Tickables.ToArray();
            foreach (var t in objectTickables) t.Tick();
        }

        private void LateUpdate()
        {
            var serviceLateTickables = _serviceContainer.LateTickables;
            foreach (var t in serviceLateTickables) t.LateTick();
            
            var objectLateTickables = _objectContainer.LateTickables;
            foreach (var t in objectLateTickables) t.LateTick();
        }

        private void OnDestroy()
        {
            var objectDisposables = _objectContainer.Disposables;
            for (var i = objectDisposables.Count - 1; i >= 0; i--) objectDisposables[i].Dispose();
            
            var serviceDisposables = _serviceContainer.Disposables;
            for (var i = serviceDisposables.Count - 1; i >= 0; i--) serviceDisposables[i].Dispose();
        }

        public void Bind(object obj)
        {
            _objectContainer.AddObject(obj);
            OnBind(obj);

            if (_wasInitialized)
            {
                if (obj is IInitializable initializable) initializable.Initialize();
            }
        }

        public void Unbind(object obj)
        {
            _objectContainer.RemoveObject(obj);
            OnUnbind(obj);
        }

        public void BindService(object service)
        {
            _serviceContainer.AddObject(service);
            OnBindService(service);
        }

        public void UnbindService(object service)
        {
            _serviceContainer.RemoveObject(service);
            OnUnbindService(service);
        }

        public T FindObject<T>()
        {
            return _objectContainer.GetObject<T>();
        }
        
        public T[] FindObjects<T>()
        {
            return _objectContainer.GetObjects<T>();
        }

        public T FindService<T>()
        {
            return _serviceContainer.GetObject<T>();
        }

        public T[] FindServices<T>()
        {
            return _serviceContainer.GetObjects<T>();
        }

        protected virtual void OnBind(object obj)
        {
        }

        protected virtual void OnUnbind(object obj)
        {
        }

        protected virtual void OnBindService(object service)
        {
        }

        protected virtual void OnUnbindService(object service)
        {
        }
        
        protected abstract void StartGameContext();
    }
}