using Asteroids.Core.Abstract;
using UnityEngine;

namespace Asteroids.Game.Entities.Saucer
{
    [CreateAssetMenu(fileName = nameof(SaucerConfig), menuName = "Asteroids/" + nameof(SaucerConfig), order = 1)]
    public class SaucerConfig : ConfigWithView<SaucerView>
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _sizeRadius;

        public float Speed => _speed;
        public float SizeRadius => _sizeRadius;
    }
}