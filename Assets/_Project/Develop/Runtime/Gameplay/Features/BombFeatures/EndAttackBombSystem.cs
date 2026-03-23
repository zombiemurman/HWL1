using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class EndAttackBombSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackBombEvent;

        private ReactiveVariable<bool> _inAttackProcess;

        private readonly EntitiesFactory _entitiesFactory;

        private Entity _entity;

        public EndAttackBombSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        IDisposable _endAttackBombEventDisposable;

        public void OnInit(Entity entity)
        {
            _endAttackBombEvent = entity.EndAttackBombEvent;

            _inAttackProcess = entity.inAttackProcess;

            _entity = entity;

            _endAttackBombEventDisposable = _endAttackBombEvent.Subscribe(OnEndAttack);
        }

        public void OnDispose()
        {
            _endAttackBombEventDisposable.Dispose();
        }
        private void OnEndAttack()
        {
            _inAttackProcess.Value = false;

            _entitiesFactory.Release(_entity);
        }
    }
}
