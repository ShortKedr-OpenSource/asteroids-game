using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;

namespace Asteroids.Game.Entities.Saucer
{
    public class SaucerModel : ILateTickable
    {
        private SaucerConfig _config;
        
        public bool ModelChanged { get; private set; }
        
        public void LateTick()
        {
            ModelChanged = false;
        }
    }
}