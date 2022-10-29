using Asteroids.Game.Configs;

namespace Asteroids.Game.Models
{
    public class SaucerModel
    {
        private SaucerConfig _config;
        
        public bool ModelChanged { get; private set; }
    }
}