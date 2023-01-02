using System.Runtime.CompilerServices;
using Asteroids.Math.Collisions.Collidables;
using Asteroids.Math.Collisions.Shapes;
using UnityEngine;

namespace Asteroids.Math.Collisions.Utils
{
    public static class RayGizmosUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawFlatRay(FlatRay flatRay)
        {
            Gizmos.DrawRay(flatRay.Origin, flatRay.Direction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRayCollidable(IRayCollidable rayCollidable)
        {
            var origin = rayCollidable.Origin;
            var dir = rayCollidable.Direction;
            float halfThickness = rayCollidable.Thickness / 2f;
            
            Vector2 normal = new Vector2(-dir.y, dir.x).normalized;
            
            Vector2 originLeft = origin + normal * halfThickness;
            Vector2 originRight = origin - normal * halfThickness;  
            
            FlatRay leftRay = new FlatRay(originLeft, dir);
            FlatRay rightRay = new FlatRay(originRight, dir);
            
            DrawFlatRay(leftRay);
            DrawFlatRay(rightRay);
        }
    }
}