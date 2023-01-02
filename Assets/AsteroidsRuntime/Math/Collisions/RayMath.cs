using System;
using Asteroids.Math.Collisions.Collidables;
using Asteroids.Math.Collisions.Shapes;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Asteroids.Math.Collisions
{

    public static class RayMath
    {
        public static bool RayIntersection(IRayCollidable first, IRayCollidable second, out Vector2 firstIntersectionPoint)
        {
            var firstOrigin = first.Origin;
            var secondOrigin = second.Origin;
            
            var firstDir = first.Direction;
            var secondDir = second.Direction;
            
            float firstHalfThickness = first.Thickness / 2f;
            float secondHalfThickness = second.Thickness / 2f;
            
            Vector2 firstNormal = new Vector2(-firstDir.y, firstDir.x).normalized;
            Vector2 secondNormal = new Vector2(-secondDir.y, secondDir.x).normalized;

            Vector2 firstOriginLeft = firstOrigin + firstNormal * firstHalfThickness;
            Vector2 firstOriginRight = firstOrigin - firstNormal * firstHalfThickness;  
            
            Vector2 secondOriginLeft = secondOrigin + secondNormal * secondHalfThickness;
            Vector2 secondOriginRight = secondOrigin - secondNormal * secondHalfThickness;

            FlatRay firstLeftRay = new FlatRay(firstOriginLeft, firstDir);
            FlatRay firstRightRay = new FlatRay(firstOriginRight, firstDir);

            FlatRay secondLeftRay = new FlatRay(secondOriginLeft, secondDir);
            FlatRay secondRightRay = new FlatRay(secondOriginRight, secondDir);

            bool intersectionOne = FlatRayIntersection(firstLeftRay, secondRightRay, out Vector2 intersectionPointOne);
            bool intersectionTwo = FlatRayIntersection(firstRightRay, secondLeftRay, out Vector2 intersectionPointTwo);

            if (intersectionOne) firstIntersectionPoint = intersectionPointOne;
            else if (intersectionTwo) firstIntersectionPoint = intersectionPointTwo;
            else firstIntersectionPoint = Vector2.zero;

            return intersectionOne || intersectionTwo;
        }

        public static bool FlatRayIntersection(FlatRay first, FlatRay second, out Vector2 intersectionPoint)
        {
            Vector2 p1 = first.Origin;
            Vector2 p2 = first.Origin + first.Direction;

            Vector2 p3 = second.Origin;
            Vector2 p4 = second.Origin + second.Direction;

            float k1 = (p2.y - p1.y) / (p2.x - p1.x);
            float k2 = (p4.y - p3.y) / (p4.x - p3.x);

            float b1 = p1.y - k1 * p1.x;
            float b2 = p3.y - k2 * p3.x;
            
            intersectionPoint.x = (b2 - b1) / (k1 - k2);
            intersectionPoint.y = k1 * intersectionPoint.x + b1;

            Vector2 minFirst = new Vector2(Mathf.Min(p1.x, p2.x), Mathf.Min(p1.y, p2.y));
            Vector2 maxFirst = new Vector2(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y));
            
            Vector2 minSecond = new Vector2(Mathf.Min(p3.x, p4.x), Mathf.Min(p3.y, p4.y));
            Vector2 maxSecond = new Vector2(Mathf.Max(p3.x, p4.x), Mathf.Max(p3.y, p4.y));
            
            bool isInFirstRay = (intersectionPoint.x >= minFirst.x  && intersectionPoint.x <= maxFirst.x 
                                && intersectionPoint.y >= minFirst.y  && intersectionPoint.y <= maxFirst.y ); 
            
            bool isInSecondRay = (intersectionPoint.x >= minSecond.x  && intersectionPoint.x <= maxSecond.x 
                                && intersectionPoint.y >= minSecond.y  && intersectionPoint.y <= maxSecond.y ); 

            return isInFirstRay && isInSecondRay;
        }
    }

}