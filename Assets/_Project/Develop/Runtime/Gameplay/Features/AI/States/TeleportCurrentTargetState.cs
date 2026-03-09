using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportCurrentTargetState : State, IUpdatableState
    {
        private ReactiveEvent _teleportManaConsumptionEvent;
        private ReactiveEvent _teleportEndedEvent;

        private ReactiveVariable<float> _radiusTeleport;

        private Transform _entityTransform;

        private ReactiveVariable<Entity> _currentTarget;

        private float _offsetDistance = 1f;

        public TeleportCurrentTargetState(Entity entity)
        {
            _radiusTeleport = entity.RadiusTeleport;
            _entityTransform = entity.EntityTransform;
            _teleportManaConsumptionEvent = entity.TeleportManaConsumptionEvent;
            _currentTarget = entity.CurrentTarget;
            _teleportEndedEvent = entity.EndTeleportEvent;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value == null)
                return;

            float distanceToTarget = (_entityTransform.position - _currentTarget.Value.EntityTransform.position).magnitude;

            if(distanceToTarget <= _offsetDistance)
                return;

            float distanceToTP = distanceToTarget;

            if (distanceToTarget > _radiusTeleport.Value)
                distanceToTP = _radiusTeleport.Value;
            else
                distanceToTP = _offsetDistance;


            Vector3 directionToTarget = (_currentTarget.Value.EntityTransform.position - _entityTransform.position).normalized;

            _entityTransform.position = _entityTransform.position + directionToTarget * distanceToTP;

            _teleportManaConsumptionEvent.Invoke();

            _teleportEndedEvent.Invoke();

        }
    }
}
