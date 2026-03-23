using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class ExplosionContactSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackEvent;

        private Buffer<Collider> _contacts;

        private ReactiveVariable<Vector3> _explosionPoint;
        private ReactiveVariable<float> _explosionRadius;

        private LayerMask _mask;

        private IDisposable _startAttackEventDisposable;

        public void OnInit(Entity entity)
        {
            _explosionPoint = entity.ExplosionPoint;
            _explosionRadius = entity.ExplosionRadius;
            _startAttackEvent = entity.StartAttackEvent;

            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;

            _startAttackEventDisposable = _startAttackEvent.Subscribe(OnAttackEvent);
        }

        private void OnAttackEvent()
        {
            _contacts.Count = Physics.OverlapCapsuleNonAlloc(
                _explosionPoint.Value + Vector3.up, 
                _explosionPoint.Value - Vector3.up,
                _explosionRadius.Value,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);

        }

        public void OnDispose()
        {
            _startAttackEventDisposable.Dispose();
        }
    }
}
