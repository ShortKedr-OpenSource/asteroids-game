using Asteroids.Core.Interfaces;
using Asteroids.Core.Interfaces.Processes;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.Laser;
using UnityEngine;

namespace Asteroids.Game.Entities.Ship
{
    public class ShipModel : ILateTickable
    {
        public ShipConfig ShipConfig { get; }
        public BulletConfig BulletConfig { get; }
        public LaserConfig LaserConfig { get; }

        private Vector2 _position;
        private float _rotation;
        private Vector2 _speed;
        private int _laserAmmo;
        private float _laserRechargeTimer;

        public bool ModelChanged { get; private set; }

        public ShipModel(ShipConfig shipConfig, BulletConfig bulletConfig, LaserConfig laserConfig)
        {
            ShipConfig = shipConfig;
            BulletConfig = bulletConfig;
            LaserConfig = laserConfig;

            ModelChanged = true;
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

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
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

        public int LaserAmmo
        {
            get => _laserAmmo;
            set
            {
                _laserAmmo = value;
                ModelChanged = true;
            }
        }

        public float LaserRechargeTimer
        {
            get => _laserRechargeTimer;
            set
            {
                _laserRechargeTimer = value;
                ModelChanged = true;
            }
        }

        void ILateTickable.LateTick()
        {
            ModelChanged = false;
        }
    }
}