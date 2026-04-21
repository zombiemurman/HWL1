using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures
{
    public class MovingToDistanceSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<bool> _isStopMoving;

        private Transform _transform;

        private ReactiveVariable<float> _moveToDistance;

        public void OnInit(Entity entity)
        {
            _isStopMoving = entity.IsStopMoving;
            _transform = entity.EntityTransform;
            _moveToDistance = entity.MovingToDistance;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isStopMoving.Value == false)
            {
                float currentDistance = (_transform.position - Vector3.zero).magnitude;

                if(currentDistance <= _moveToDistance.Value)
                    _isStopMoving.Value = true;    
            }
        }
    }
}
