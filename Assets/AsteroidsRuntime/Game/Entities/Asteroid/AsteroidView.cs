using UnityEngine;

namespace Asteroids.Game.Entities.Asteroid
{
    public class AsteroidView : MonoBehaviour
    {
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}