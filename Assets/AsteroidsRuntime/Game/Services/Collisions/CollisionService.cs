using System.Collections.Generic;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Math.Collisions.Collidables;

namespace Asteroids.Math.Collisions
{
    // TODO add ray collidable
    
    public class CollisionService : ITickable
    {
        private readonly List<ICircleCollidable> _circleCollidables = new List<ICircleCollidable>(64);
        private readonly HashSet<ICircleCollidable> _circleCollidablesHash = new HashSet<ICircleCollidable>();

        private readonly List<IRayCollidable> _rayCollidables = new List<IRayCollidable>(64);
        private readonly HashSet<IRayCollidable> _rayCollidablesHash = new HashSet<IRayCollidable>();

        public IReadOnlyList<ICircleCollidable> CircleCollidables => _circleCollidables;

        public void Add(object obj)
        {
            if (obj is ICircleCollidable circleCollidable)
            {
                _circleCollidables.Add(circleCollidable);
                _circleCollidablesHash.Add(circleCollidable);
            }

            if (obj is IRayCollidable rayCollidable)
            {
                _rayCollidables.Add(rayCollidable);
                _rayCollidablesHash.Add(rayCollidable);
            }
        }

        public void Remove(object obj)
        {
            if (obj is ICircleCollidable circleCollidable)
            {
                _circleCollidables.Remove(circleCollidable);
                _circleCollidablesHash.Remove(circleCollidable);

            }

            if (obj is IRayCollidable rayCollidable)
            {
                _rayCollidables.Remove(rayCollidable);
                _rayCollidablesHash.Remove(rayCollidable);
            }
        }
        
        void ITickable.Tick()
        {
            var circleCollidables = _circleCollidables.ToArray();
            var rayCollidables = _rayCollidables.ToArray();
            
            for (int i = 0; i < circleCollidables.Length; i++)
            {
                if (circleCollidables[i] == null) continue;
                if (!_circleCollidablesHash.Contains(circleCollidables[i])) continue;
                
                for (int j = i+1; j < circleCollidables.Length; j++)
                {
                    
                    if (circleCollidables[j] == null) continue;
                    if (!_circleCollidablesHash.Contains(circleCollidables[j])) continue;

                    if (CollisionMath.CheckCollision(circleCollidables[i], circleCollidables[j])) {
                        circleCollidables[i].OnCollisionHappen(circleCollidables[j]);
                        circleCollidables[j].OnCollisionHappen(circleCollidables[i]);
                    }
                }
            }

            for (int i = 0; i < rayCollidables.Length; i++)
            {
                if (rayCollidables[i] == null) continue;
                if (!_rayCollidablesHash.Contains(rayCollidables[i])) continue;
                
                for (int j = i+1; j < rayCollidables.Length; j++)
                {
                    
                    if (rayCollidables[j] == null) continue;
                    if (!_rayCollidablesHash.Contains(rayCollidables[j])) continue;

                    if (CollisionMath.CheckCollision(rayCollidables[i], rayCollidables[j])) {
                        rayCollidables[i].OnCollisionHappen(rayCollidables[j]);
                        rayCollidables[j].OnCollisionHappen(rayCollidables[i]);
                    }
                }
            }
            
            for (int i = 0; i < circleCollidables.Length; i++)
            {
                if (circleCollidables[i] == null) continue;
                if (!_circleCollidablesHash.Contains(circleCollidables[i])) continue;
                
                for (int j = 0; j < rayCollidables.Length; j++)
                {
                    
                    if (rayCollidables[j] == null) continue;
                    if (!_rayCollidablesHash.Contains(rayCollidables[j])) continue;

                    if (CollisionMath.CheckCollision(circleCollidables[i], rayCollidables[j])) {
                        circleCollidables[i].OnCollisionHappen(rayCollidables[j]);
                        rayCollidables[j].OnCollisionHappen(circleCollidables[i]);
                    }
                }
            }
        }
    }
}