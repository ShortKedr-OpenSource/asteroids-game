using System;
using System.Collections.Generic;
using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;

namespace Asteroids.Core
{
    public class LifeCycleContainer
    {
        public List<object> objects { get; } = new List<object>(64);
        public List<IInitializable> Initializables { get; } = new List<IInitializable>(64);
        public List<ITickable> Tickables { get; } = new List<ITickable>(64);
        public List<ILateTickable> LateTickables { get; } = new List<ILateTickable>(64);
        public List<IDisposable> Disposables { get; } = new List<IDisposable>(64);

        public void Bind(object obj)
        {
            objects.Add(obj);
            if (obj is IInitializable initializable) Initializables.Add(initializable);
            if (obj is ITickable tickable) Tickables.Add(tickable);
            if (obj is ILateTickable lateTickable) LateTickables.Add(lateTickable);
            if (obj is IDisposable disposable) Disposables.Add(disposable);
        }

        public void Unbind(object obj)
        {
            objects.Remove(obj);
            if (obj is IInitializable initializable) Initializables.Remove(initializable);
            if (obj is ITickable tickable) Tickables.Remove(tickable);
            if (obj is ILateTickable lateTickable) LateTickables.Remove(lateTickable);
            if (obj is IDisposable disposable) Disposables.Remove(disposable);
        }

        public T GetObject<T>()
        {
            foreach (var obj in objects)
            {
                if (obj is T typedObj) return typedObj;
            }

            return default;
        }

        public T[] GetObjects<T>()
        {
            List<T> result = new List<T>(64);
            foreach (var obj in objects)
            {
                if (obj is T typedObj) result.Add(typedObj);
            }

            return result.ToArray();
        }
    }
}