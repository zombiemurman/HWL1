using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class ExplosionDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _endAttackEvent;

        private Buffer<Entity> _contacts;

        private ReactiveVariable<float> _damage;

        private ReactiveVariable<bool> _inAttackProcess;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _damage = entity.ExplosionDamage;
            _inAttackProcess = entity.inAttackProcess;
            _endAttackEvent = entity.EndAttackEvent;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (contactEntity.HasComponent<TakeDamageRequest>())
                {
                    contactEntity.TakeDamageRequest.Invoke(_damage.Value);
                }
            }

            _endAttackEvent.Invoke();
        }
    }
}
