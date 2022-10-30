using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;
using UnityEngine;

namespace Asteroids.Game.Entities.Bullet
{
    public class BulletModel : ILateTickable
    {
        public BulletConfig Config { get; }
        public float Direction { get; }
        public Vector2 Speed { get; }

        private Vector2 _position;

        public bool ModelChanged { get; private set; }

        public BulletModel(BulletConfig config, float direction)
        {
            Config = config;
            Direction = direction;

            ModelChanged = true;

            float rads = Direction * Mathf.Deg2Rad;
            Speed = new Vector2
            {
                x = Mathf.Cos(rads) * config.BulletSpeed, 
                y = Mathf.Sin(rads) * config.BulletSpeed, 
            };
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

        void ILateTickable.LateTick()
        {
            ModelChanged = false;
        }
    }
}