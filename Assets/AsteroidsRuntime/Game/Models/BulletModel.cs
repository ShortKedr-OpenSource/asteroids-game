using Asteroids.Game.Configs;

namespace Asteroids.Game.Models
{
    public class BulletModel
    {
        private BulletConfig _config;
        
        public bool ModelChanged { get; private set; }
    }
}