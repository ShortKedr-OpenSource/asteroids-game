using System.Collections.Generic;
using Asteroids.Core.Interfaces.Processes;

namespace Asteroids.Math.Collisions
{
    public class CollisionService : ITickable
    {
        private List<ICircleCollidable> _circleCollidables = new List<ICircleCollidable>(64);
        private HashSet<ICircleCollidable> _circleCollidablesHash = new HashSet<ICircleCollidable>();

        public IReadOnlyList<ICircleCollidable> CircleCollidables => _circleCollidables;

        public void Add(object obj)
        {
            if (obj is ICircleCollidable circleCollidable)
            {
                _circleCollidables.Add(circleCollidable);
                _circleCollidablesHash.Add(circleCollidable);
            }
        }

        public void Remove(object obj)
        {
            if (obj is ICircleCollidable circleCollidable)
            {
                _circleCollidables.Remove(circleCollidable);
                _circleCollidablesHash.Remove(circleCollidable);

            }
        }
        
        void ITickable.Tick()
        {
            var circleCollidables = _circleCollidables.ToArray();
            
            for (int i = 0; i < circleCollidables.Length; i++)
            {
                if (circleCollidables[i] == null) continue;
                if (!_circleCollidablesHash.Contains(circleCollidables[i])) continue;
                
                for (int j = i+1; j < circleCollidables.Length; j++)
                {
                    
                    if (circleCollidables[j] == null) continue;
                    if (!_circleCollidablesHash.Contains(circleCollidables[j])) continue;

                    if (CollisionChecker.CheckCircleCollision(circleCollidables[i], circleCollidables[j])) {
                        circleCollidables[i].OnCollisionHappen(circleCollidables[j]);
                        circleCollidables[j].OnCollisionHappen(circleCollidables[i]);
                    }
                }
            }
        }
    }
}