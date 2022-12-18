using System;
using Asteroids.Math.Collisions.Shapes;
using UnityEngine;
using Ray = Asteroids.Math.Collisions.Shapes.Ray;

namespace Asteroids.Math.Collisions
{

    public class CollisionsRayTest : MonoBehaviour
    {
        public Vector2 FirstOrigin = new Vector2(1, 1); 
        public Vector2 FirstDirection = new Vector3(1, 1).normalized * 10f; 
        
        public Vector2 SecondOrigin = new Vector2(-1, 1); 
        public Vector2 SecondDirection = new Vector3(1.5f, 1).normalized * 10f;
        
        private void OnDrawGizmos()
        {
            FlatRay ray1 = new FlatRay(FirstOrigin, FirstDirection);
            FlatRay ray2 = new FlatRay(SecondOrigin, SecondDirection);

            bool intersection = RayMath.FlatRayIntersection(ray1, ray2, out Vector2 intersectionPoint);

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(ray1.Origin, ray1.Direction);

            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(ray2.Origin, ray2.Direction);

            Gizmos.color = (intersection) ? Color.green : Color.red;
            Gizmos.DrawWireCube(intersectionPoint, Vector3.one * 0.5f);
        }
    }

}