using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Asteroids.Game.Utils
{
    public static class GLHelper
    {
        public static readonly Material Material = new Material(Shader.Find("Unlit/Color"));

        public static void DrawCircle(Vector3 center, float radius, Color color, float segments = 32)
        {
            GL.PushMatrix();
            Material.SetPass(0);
            Material.color = color;
            GL.Begin(GL.LINES);
            GL.Color(color);
            float fullCircle = 2f * Mathf.PI;
            float oneSegment = fullCircle / segments;
            for (float value = oneSegment; value <= (fullCircle + 0.01f); value += oneSegment)
            {
                Vector3 p0 = new Vector3()
                {
                    x = center.x + Mathf.Cos(value-oneSegment) * radius,
                    y = center.y + Mathf.Sin(value-oneSegment) * radius,
                    z = center.z,
                }; 
                
                Vector3 p1 = new Vector3()
                {
                    x = center.x + Mathf.Cos(value) * radius,
                    y = center.y + Mathf.Sin(value) * radius,
                    z = center.z,
                }; 
                
                GL.Vertex3(p0.x, p0.y, p0.z);
                GL.Vertex3(p1.x, p1.y, p1.z);
            }

            GL.End();
            GL.PopMatrix();
        }

        public static void DrawBounds(Bounds bounds, Color color)
        {
            GL.PushMatrix();
            Material.SetPass(0);
            Material.color = color;
            GL.Begin(GL.LINES);
            GL.Color(color);

            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.min.z);
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.min.z);
            
            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.min.z);
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.min.z);
            
            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.min.z);
            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.max.z);
            
            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.max.z);
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.max.z);
            
            GL.Vertex3(bounds.min.x, bounds.min.y, bounds.max.z);
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.max.z);
            
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.min.z);
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.min.z);
            
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.max.z);
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.max.z);
            
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.min.z);
            GL.Vertex3(bounds.min.x, bounds.max.y, bounds.max.z);
            
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.max.z);
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.max.z);
            
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.max.z);
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.min.z);
            
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.min.z);
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.min.z);
            
            GL.Vertex3(bounds.max.x, bounds.max.y, bounds.min.z);
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.min.z);
            
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.min.z);
            GL.Vertex3(bounds.max.x, bounds.min.y, bounds.max.z);

            GL.End();
            GL.PopMatrix();
        }
    }
}