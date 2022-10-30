using System;
using Asteroids.Core.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Game.Entities.Asteroid
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfig), menuName = "Asteroids/" + nameof(AsteroidConfig), order = 1)]
    public class AsteroidConfig : ConfigWithView<AsteroidView>
    {
        [SerializeField] private SeparationConfig[] _separationConfigs;
        [SerializeField] private float sizeRadius;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        public SeparationConfig[] SeparationConfigs => _separationConfigs;
        public float SizeRadius => sizeRadius;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;


        public AsteroidConfig[] GetRandomSeparationConfigs()
        {
            if (_separationConfigs.Length == 0) return Array.Empty<AsteroidConfig>();
            return _separationConfigs[Random.Range(0, _separationConfigs.Length)].Configs;
        }
        
        
        [Serializable]
        public struct SeparationConfig
        {
            public AsteroidConfig[] Configs;
        }
    }
}