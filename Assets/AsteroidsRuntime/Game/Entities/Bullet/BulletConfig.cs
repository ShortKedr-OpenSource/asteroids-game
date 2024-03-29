using Asteroids.Core.Abstract;
using UnityEngine;

namespace Asteroids.Game.Entities.Bullet
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = "Asteroids/" + nameof(BulletConfig), order = 1)]
    public class BulletConfig : ConfigWithView<BulletView>
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _sizeRadius;

        public float BulletSpeed => _bulletSpeed;
        public float Damage => _damage;
        public float SizeRadius => _sizeRadius;
    }
}