using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class ExplosionState : State, IUpdatableState
    {
        ReactiveEvent _startAttackRequest;

        private ReactiveVariable<Vector3> _explosionPoint;
        private Camera _camera;

        public ExplosionState(Entity entity)
        {
            _explosionPoint = entity.ExplosionPoint;

            _startAttackRequest = entity.StartAttackRequest;

            _camera = entity.ExplosionCamera;
        }

        public void Update(float deltaTime)
        {
            if (_explosionPoint.Value != Vector3.zero)
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
