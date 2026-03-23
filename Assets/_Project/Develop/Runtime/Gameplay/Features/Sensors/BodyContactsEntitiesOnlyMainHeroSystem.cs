using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BodyContactsEntitiesOnlyMainHeroSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contactEntities;

        private ReactiveVariable<bool> _inAttackProcess;

        public void OnInit(Entity entity)
        {
            _contactEntities = entity.ContactEntitiesBuffer;
            _inAttackProcess = entity.inAttackProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            bool hasMainHero = false;
            Entity mainHero = null;

            for (int i = 0; i < _contactEntities.Count; i++)
            {
                Entity contactEntity = _contactEntities.Items[i];

                if (contactEntity.HasComponent<IsMainHero>())
                {
                    hasMainHero = true;
                    mainHero = contactEntity;
                    break;
                }
            }

            for (int i = 0; i < _contactEntities.Count; i++)
            {
                _contactEntities.Items[i] = null;
            }

            _contactEntities.Count = 0;

            if (hasMainHero)
            {
                _contactEntities.Count = 1;
                _contactEntities.Items[0] = mainHero;
            }
        }
    }
}
