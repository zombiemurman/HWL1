using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class DetectedBombSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _startTimerBombEvent;

        private ReactiveVariable<float> _radius;

        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveVariable<bool> _inBombTimeProcess;

        private Buffer<Collider> _contacts;

        private Transform _transform;

        private LayerMask _mask;

        public void OnInit(Entity entity)
        {
            _radius = entity.RadiusAttack;
            _inAttackProcess = entity.inAttackProcess;
            _inBombTimeProcess = entity.InBombTimeProcess;
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _transform = entity.EntityTransform;

            _startTimerBombEvent = entity.StartTimeBombEvent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value)
                return;

            if (_inBombTimeProcess.Value)
                return;

            Vector3 bottom = _transform.position + Vector3.up;
            Vector3 top = _transform.position - Vector3.up;

            int countDetected = Physics.OverlapCapsuleNonAlloc(
                bottom,
                top,
                _radius.Value,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);

            if (countDetected > 0)
                _startTimerBombEvent.Invoke();
        }
    }
}
