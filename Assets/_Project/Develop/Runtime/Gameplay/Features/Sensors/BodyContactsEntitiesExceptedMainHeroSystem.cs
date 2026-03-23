using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BodyContactsEntitiesExceptedMainHeroSystem : IInitializableSystem, IUpdatableSystem
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

            int indexToRemove = -1;

            for (int i = 0; i < _contactEntities.Count; i++)
            {
                Entity contactEntity = _contactEntities.Items[i];

                if (contactEntity.HasComponent<IsMainHero>())
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contactEntities.Count - 1; i++)
                {
                    _contactEntities.Items[i] = _contactEntities.Items[i + 1];
                }

                _contactEntities.Count--;
            }
        }
    }
}
