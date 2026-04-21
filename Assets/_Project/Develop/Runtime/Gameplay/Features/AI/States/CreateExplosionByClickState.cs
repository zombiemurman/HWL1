using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class CreateExplosionByClickState : State, IUpdatableState
    {
        ReactiveEvent _startAttackRequest;

        private IInputService _inputService;

        private ReactiveVariable<Vector3> _explosionPoint;

        private ReactiveVariable<bool> _abilityActive;

        public CreateExplosionByClickState(Entity entity, IInputService inputService)
        {
            Entity explosionEntity = entity.AbilityStorage[AbilityTipes.Explosion];

            _explosionPoint = explosionEntity.ExplosionPoint;

            _startAttackRequest = explosionEntity.StartAttackRequest;

            _inputService = inputService;

            _abilityActive = explosionEntity.AbilityActive;
        }

        public void Update(float deltaTime)
        {
            if (_abilityActive.Value == false)
                return;

            if (_explosionPoint.Value != Vector3.zero)
                return;

            if(_inputService.Direction != Vector3.zero)
            {
                _explosionPoint.Value = _inputService.Direction;

                _startAttackRequest.Invoke();
            }
        }
    }
}
