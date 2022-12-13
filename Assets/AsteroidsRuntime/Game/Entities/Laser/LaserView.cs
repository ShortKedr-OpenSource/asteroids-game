using System;
using UnityEngine;

namespace Asteroids.Game.Entities.Laser
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private float _onePieceLength;

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
        
        public void SetDirection(float angle)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle-90f);
        }

        public void SetLength(float length)
        {
            var myTransform = transform;
            Vector3 scale = myTransform.localScale;

            scale.y = (1f / _onePieceLength) * length;
            
            myTransform.localScale = scale;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Vector3 position = transform.position;
            Gizmos.DrawLine(position, position + Vector3.up * _onePieceLength);
        }
#endif
        
    }
}