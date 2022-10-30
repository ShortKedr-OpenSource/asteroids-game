using System;
using UnityEngine;

namespace Asteroids.Game.Entities.CameraPortal
{
    public class CameraPortalModel
    {
        public Camera Camera { get; private set; }

        public event Action<CameraPortalModel, Camera> OnCameraChanged;

        public void SetCamera(Camera camera)
        {
            Camera = camera;
            OnCameraChanged?.Invoke(this, camera);
        }

        public Bounds GetCameraPortalBounds()
        {
            if (Camera == null) return new Bounds(Vector3.zero, Vector3.zero);
            Bounds bounds = new Bounds(Camera.transform.position,
                new Vector3(1f * Camera.aspect, 1f, 0f) * (Camera.orthographicSize * 2f));
            return bounds;
        }
    }
}