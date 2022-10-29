using Asteroids.Core.Abstract;
using Asteroids.Game.Views;
using UnityEngine;

namespace Asteroids.Game.Configs
{
    [CreateAssetMenu(fileName = nameof(ShipConfig), menuName = "Asteroids/" + nameof(ShipConfig), order = 1)]
    public class ShipConfig : ConfigWithView<ShipView>
    {
        [SerializeField] private float _sizeRadius;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private float _speedIncrement;
        [SerializeField] private float _friction;
        [SerializeField] private float _maxSpeed;

        public float SizeRadius => _sizeRadius;
        public float TurnSpeed => _turnSpeed;
        public float SpeedIncrement => _speedIncrement;
        public float Friction => _friction;
        public float MaxSpeed => _maxSpeed;
    }
}