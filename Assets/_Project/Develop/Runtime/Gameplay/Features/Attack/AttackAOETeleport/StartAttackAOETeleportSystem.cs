using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackAOETeleport
{
    public class StartAttackAOETeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endTeleportEvent;
        
        private ReactiveVariable<bool> _inAttackProcess;

        private IDisposable _endTeleportDispouse;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.inAttackProcess;
            _endTeleportEvent = entity.EndTeleportEvent;

            _endTeleportDispouse = _endTeleportEvent.Subscribe(OnEndTeleport);
        }

        public void OnDispose()
        {
            _endTeleportDispouse.Dispose();
        }

        private void OnEndTeleport()
        {
            _inAttackProcess.Value = true;
        }
    }
}
