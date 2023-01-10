using UnityEngine;

namespace Asteroids.Game.Entities.Ship
{
    public class ShipView : MonoBehaviour
    {
        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}