using Asteroids.Core.Abstract;
using UnityEngine;

namespace Asteroids.Game.Entities.Laser
{
    [CreateAssetMenu(fileName = nameof(LaserConfig), menuName = "Asteroids/" + nameof(LaserConfig), order = 1)]
    public class LaserConfig : ConfigWithView<LaserView>
    {
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _ammoRechargeTime;

        public int MaxAmmo => _maxAmmo;
        public float AmmoRechargeTime => _ammoRechargeTime;
    }
}