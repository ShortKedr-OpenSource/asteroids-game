using Asteroids.Core;
using Asteroids.Core.Abstract;
using Asteroids.Game.Models;
using Asteroids.Game.Views;
using Asteroids.Core.Interfaces;
using Asteroids.Game.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Presenters
{
    public class ShipPresenter : ContextPresenter<ShipModel, ShipView>,
        IInitializable, ITickable
    {
        public ShipPresenter(ShipModel model, ShipView view, GameContext context)
            : base(model, view, context)
        {
        }

        void IInitializable.Initialize()
        {
            Debug.Log("Initialize");
        }

        void ITickable.Tick()
        {
            var shipConfig = Model.ShipConfig;
            var bulletConfig = Model.BulletConfig;
            var laserConfig = Model.LaserConfig;
            
            if (Input.GetKey(KeyCode.A)) Model.Rotation += shipConfig.TurnSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)) Model.Rotation -= shipConfig.TurnSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
            {
                Vector2 speedIncrement = MathUtil.RotationToVector(Model.Rotation) * shipConfig.SpeedIncrement;
                Model.Speed += speedIncrement * Time.deltaTime;
            }

            Model.Position += Model.Speed * Time.deltaTime;
            Model.Speed -= Model.Speed.normalized * (shipConfig.Friction * Time.deltaTime);
            if (Model.Speed.magnitude > shipConfig.MaxSpeed) Model.Speed = Model.Speed.normalized * shipConfig.MaxSpeed;

            if (Model.ModelChanged)
            {
                View.SetPosition(Model.Position);
                View.SetRotation(Model.Rotation);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (View != null) Object.Destroy(View.gameObject);
        }
    }
}