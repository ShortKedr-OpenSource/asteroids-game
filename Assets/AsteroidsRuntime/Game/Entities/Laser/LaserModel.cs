using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserModel : ILateTickable
    {
        public LaserConfig Config { get; }

        private float _direction;
        private float _length;
        private Vector2 _origin;

        public bool ModelChanged { get; private set; }
        
        public LaserModel(LaserConfig config)
        {
            Config = config;
            ModelChanged = false;
        }

        public float Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                ModelChanged = true;
            }
        }

        public float Length
        {
            get => _length;
            set
            {
                _length = value;
                ModelChanged = true;
            }
        }

        public Vector2 Origin
        {
            get => _origin;
            set
            {
                _origin = value;
                ModelChanged = true;
            }
        }

        void ILateTickable.LateTick()
        {
            ModelChanged = false;
        }
    }
}