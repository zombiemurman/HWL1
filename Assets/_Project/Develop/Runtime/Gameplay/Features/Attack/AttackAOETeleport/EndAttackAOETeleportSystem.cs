using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackAOETeleport
{
    public class EndAttackAOETeleportSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inAttackProcess;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.inAttackProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            _inAttackProcess.Value = false;
        }
    }
}
