using UnityEngine;

namespace Asteroids.Game.Entities.Bullet
{
    public class BulletView : MonoBehaviour
    {
        public void SetRotation(float degrees)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, degrees));
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}