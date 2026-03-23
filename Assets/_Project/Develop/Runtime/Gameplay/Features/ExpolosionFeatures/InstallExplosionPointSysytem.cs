using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class InstallExplosionPointSysytem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _startAttackRequest;

        private ReactiveVariable<Vector3> _explosionPoint;

        private Camera _camera;

        public void OnInit(Entity entity)
        {
            _explosionPoint = entity.ExplosionPoint;
            _camera = entity.ExplosionCamera;
            _startAttackRequest = entity.StartAttackRequest;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_explosionPoint.Value != Vector3.zero)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, Layers.GroundMask))
                {
                    _explosionPoint.Value = hit.point;

                    _startAttackRequest.Invoke();
                }
            }
        }
    }
}
