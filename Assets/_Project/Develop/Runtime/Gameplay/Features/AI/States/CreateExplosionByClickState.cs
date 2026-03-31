using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
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

        private ReactiveVariable<bool> _itSetExplosion;

        public CreateExplosionByClickState(Entity entity, IInputService inputService)
        {
            _explosionPoint = entity.ExplosionPoint;

            _startAttackRequest = entity.StartAttackRequest;

            _inputService = inputService;

            _itSetExplosion = entity.ItSetExplosion;
        }

        public void Update(float deltaTime)
        {
            if (_itSetExplosion.Value == false)
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
