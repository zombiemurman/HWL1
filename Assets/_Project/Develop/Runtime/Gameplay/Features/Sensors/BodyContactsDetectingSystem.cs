using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BodyContactsDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inAttackProcess;

        private ReactiveVariable<float> _radius;

        private Buffer<Collider> _contacts;

        private CapsuleCollider _body;

        private Transform _transform;

        private LayerMask _mask;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.inAttackProcess;
            _radius = entity.RadiusAttack;
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _transform = entity.EntityTransform;
            _body = entity.BodyCollider;
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

            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }

                _contacts.Count--;
            }
        }
    }
}
