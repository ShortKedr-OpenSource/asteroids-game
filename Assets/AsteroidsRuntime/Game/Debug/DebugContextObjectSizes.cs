using Asteroids.Core;
using Asteroids.Game.Utils;
using Asteroids.Game.Entities.Asteroid;
using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Entities.CameraPortal;
using Asteroids.Game.Entities.Laser;
using Asteroids.Game.Entities.Saucer;
using Asteroids.Game.Entities.Ship;
using UnityEditor.Graphs;
using UnityEngine;

namespace Asteroids.Game.Editor.Debug
{
#if UNITY_EDITOR
    public class DebugContextObjectSizes
    {
        private readonly GameContext _context;

        public DebugContextObjectSizes(GameContext context)
        {
            _context = context;
        }
        
        public void DebugDrawSizesGizmo()
        {
            Gizmos.color = Color.green;

            var cameraPortal = _context.FindObject<CameraPortalModel>();
            GLHelper.DrawBounds(cameraPortal.GetCameraPortalBounds(), Color.green);
            
            var ships = _context.FindObjects<ShipModel>();
            foreach (var ship in ships)
            {
                GLHelper.DrawCircle(ship.Position, ship.ShipConfig.SizeRadius, Color.green);
            }

            var asteroids = _context.FindObjects<AsteroidModel>();
            foreach (var asteroid in asteroids)
            {
                GLHelper.DrawCircle(asteroid.Position, asteroid.Config.SizeRadius, Color.green);
            }

            var bullets = _context.FindObjects<BulletModel>();
            foreach (var bullet in bullets)
            {
                GLHelper.DrawCircle(bullet.Position, bullet.Config.SizeRadius, Color.green);
            }

            var lasers = _context.FindObjects<LaserModel>();
            foreach (var laser in lasers)
            {
                Vector2 direction = new Vector2()
                {
                    x = Mathf.Cos(laser.Direction * Mathf.Deg2Rad) * laser.Length,
                    y = Mathf.Sin(laser.Direction * Mathf.Deg2Rad) * laser.Length,
                };
                GLHelper.DrawThickRay2D(laser.Origin, direction, laser.Config.Thickness, Color.green);
            }
            
            var saucers = _context.FindObjects<SaucerModel>();
        }
    }
#endif
}