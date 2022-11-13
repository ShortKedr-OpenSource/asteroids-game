using UnityEngine;

namespace Asteroids.Game.Entities.Asteroid
{
    public class AsteroidView : MonoBehaviour
    {
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetRotation(float angle) {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}