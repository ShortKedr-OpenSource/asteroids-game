using UnityEngine;

namespace Asteroids.Game.Views
{
    public class AsteroidView : MonoBehaviour
    {
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}