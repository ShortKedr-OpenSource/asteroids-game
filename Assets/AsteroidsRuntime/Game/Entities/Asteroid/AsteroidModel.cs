using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Game.Entities.Asteroid
{
    public class AsteroidModel : ILateTickable
    {
        public AsteroidConfig Config { get; }
        public AsteroidConfig[] SeparationConfigs { get; }
        
        private Vector2 _position;
        private Vector2 _speed;

        public bool ModelChanged { get; private set; }
        
        public AsteroidModel(AsteroidConfig config, AsteroidConfig[] separationConfigs)
        {
            Config = config;
            SeparationConfigs = separationConfigs;

            ModelChanged = false;
        }


        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                ModelChanged = true;
            }
        }

        public Vector2 Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                ModelChanged = true;
            }
        }


        void ILateTickable.LateTick()
        {
            ModelChanged = false;
        }
    }
}