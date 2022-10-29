using Asteroids.Game.Configs;

namespace Asteroids.Game.Models
{
    public class LaserModel
    {
        private LaserConfig _config;
        
        public bool ModelChanged { get; private set; }
    }
}