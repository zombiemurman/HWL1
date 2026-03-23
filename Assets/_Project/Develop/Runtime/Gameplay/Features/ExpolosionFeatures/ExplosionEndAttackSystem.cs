using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class ExplosionEndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackEvent;

        private ReactiveVariable<bool> _inAttackProcess;

        private ReactiveVariable<Vector3> _explosionPoint;

        IDisposable _endAttackDisposable;

        public void OnInit(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.inAttackProcess;
            _explosionPoint = entity.ExplosionPoint;

            _endAttackDisposable = _endAttackEvent.Subscribe(OnEndAttack);
        }

        private void OnEndAttack()
        {
            _inAttackProcess.Value = false;

            _explosionPoint.Value = Vector3.zero;
        }

        public void OnDispose()
        {
            _endAttackDisposable.Dispose();
        }
    }
}
