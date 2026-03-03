using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TakeDamage
{
    public class DealDamageOnAOETeleportSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contacts;

        private ReactiveVariable<float> _damage;

        private ReactiveVariable<bool> _inAttackProcess;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _damage = entity.DamageAttack;
            _inAttackProcess = entity.inAttackProcess;
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
        }
    }
}
