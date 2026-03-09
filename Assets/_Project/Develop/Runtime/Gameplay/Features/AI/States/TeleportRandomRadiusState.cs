using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Teleport;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportRandomRadiusState : State, IUpdatableState
    {
        private ReactiveEvent _startTeleportRequest;

        public TeleportRandomRadiusState(Entity entity)
        {
            _startTeleportRequest = entity.StartTeleportRequest;

        }

        public override void Enter()
        {
            base.Enter();

            _startTeleportRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}
