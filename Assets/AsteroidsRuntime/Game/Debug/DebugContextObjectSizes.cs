using Asteroids.Core;
using Asteroids.Game.Models;
using Asteroids.Game.Utils;
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

            var ships = _context.FindObjects<ShipModel>();
            foreach (var ship in ships)
            {
                GLHelper.DrawCircle(ship.Position, ship.ShipConfig.SizeRadius, Color.green);
            }

            var asteroids = _context.FindObjects<AsteroidModel>();
            UnityEngine.Debug.Log(asteroids.Length);
            foreach (var asteroid in asteroids)
            {
                GLHelper.DrawCircle(asteroid.Position, asteroid.Config.SizeRadius, Color.green);
            }
            
            var saucers = _context.FindObjects<SaucerModel>();
            var bullets = _context.FindObjects<BulletModel>();
        }
    }
#endif
}