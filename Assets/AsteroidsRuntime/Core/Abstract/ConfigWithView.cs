using UnityEngine;

namespace Asteroids.Core.Abstract
{
    public class ConfigWithView<TView> : ScriptableObject
    {
        [SerializeField] private TView _viewPrefab;

        public TView ViewPrefab => _viewPrefab;
    }
}