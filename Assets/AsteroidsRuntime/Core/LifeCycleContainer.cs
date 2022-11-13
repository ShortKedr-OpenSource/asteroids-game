using System;
using System.Collections.Generic;
using Asteroids.Core.Helpers;
using Asteroids.Core.Interfaces.Processes;

namespace Asteroids.Core
{
    public class LifeCycleContainer
    {
        private readonly List<object> _objects = new(64);
        private HashSet<object> _objectsHash = new();
        
        private readonly List<IInitializable> _initializables = new(64);
        private readonly List<ITickable> _tickables = new(64);
        private readonly List<ILateTickable> _lateTickables = new(64);
        private readonly List<IDisposable> _disposables = new(64);

        public IReadOnlyList<object> Objects => _objects;
        public IReadOnlyList<IInitializable> Initializables => _initializables;
        public IReadOnlyList<ITickable> Tickables => _tickables;
        public IReadOnlyList<ILateTickable> LateTickables => _lateTickables;
        public IReadOnlyList<IDisposable> Disposables => _disposables;
        

        public void AddObject(object obj)
        {
            if (_objectsHash.Contains(obj))
            {
                throw new Exception($"Unable to add object {obj.GetType().Name}. Object is already exists");
            }

            _objects.Add(obj);
            _objectsHash.Add(obj);
            
            if (obj is IInitializable initializable) _initializables.Add(initializable);
            if (obj is ITickable tickable) _tickables.Add(tickable);
            if (obj is ILateTickable lateTickable) _lateTickables.Add(lateTickable);
            if (obj is IDisposable disposable) _disposables.Add(disposable);
        }

        public bool RemoveObject(object obj)
        {
            if (!_objectsHash.Contains(obj)) return false;
            
            _objects.Remove(obj);
            _objectsHash.Remove(obj);
            
            if (obj is IInitializable initializable) _initializables.Remove(initializable);
            if (obj is ITickable tickable) _tickables.Remove(tickable);
            if (obj is ILateTickable lateTickable) _lateTickables.Remove(lateTickable);
            if (obj is IDisposable disposable) _disposables.Remove(disposable);

            return true;
        }

        public T GetObject<T>()
        {
            foreach (var obj in _objects)
            {
                if (obj is T typedObj) return typedObj;
            }

            return default;
        }

        public T[] GetObjects<T>()
        {
            var result = OperationStructures<T>.List;
            result.Clear();
            foreach (var obj in _objects)
            {
                if (obj is T typedObj) result.Add(typedObj);
            }

            return result.ToArray();
        }
    }
}