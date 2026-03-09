using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class AttackTriggerState : State, IUpdatableState
    {
        private IInputService _inputService;

        private ReactiveEvent _attackRequest;

        public AttackTriggerState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;

            _attackRequest = entity.StartAttackRequest;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.KeyAction)
                _attackRequest.Invoke();
        }
    }
}
