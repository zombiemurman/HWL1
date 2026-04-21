using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class AttackRadiusContactsDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inAttackProcess;

        private Buffer<Collider> _contacts;

        private ReactiveVariable<float> _radius;

        private Transform _transform;

        private LayerMask _mask;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.inAttackProcess;
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _transform = entity.EntityTransform;
            _radius = entity.RadiusAttack;

        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            Vector3 bottom = _transform.position + Vector3.up;
            Vector3 top = _transform.position - Vector3.up;

            _contacts.Count = Physics.OverlapCapsuleNonAlloc(
                bottom,
                top,
                _radius.Value,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);
        }
    }
}
