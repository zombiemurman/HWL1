using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHero
{
    public class MainHeroHolderService : IInitializable, IDisposable
    {
        private ReactiveEvent<Entity> _heroRegistred = new();

        private EntitiesLifeContext _entitiesLifeContext;

        private Entity _mainHero;

        public MainHeroHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent<Entity> HeroRegistred => _heroRegistred;

        public Entity MainHero => _mainHero;
        
        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
        }

        public void SetMine()
        {
            AbilityActivityOff();

            SetAbilityActiveOn(AbilityTypes.Mine);
        }

        public void SetTurel()
        {
            AbilityActivityOff();

            SetAbilityActiveOn(AbilityTypes.Turret);
        }

        public void SetPuddle()
        {
            AbilityActivityOff();

            SetAbilityActiveOn(AbilityTypes.Puddle);
        }

        public void SetExplosion()
        {
            AbilityActivityOff();

            SetAbilityActiveOn(AbilityTypes.Explosion);
        }

        public void SetAbilityBy(AbilityTypes abilityTypes)
        {
            AbilityActivityOff();

            SetAbilityActiveOn(abilityTypes);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
        }

        private void OnEntityAdded(Entity entity)
        {
            if(entity.HasComponent<IsMainHero>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;

                _mainHero = entity;

                _heroRegistred?.Invoke(entity);
            }
        }

        private void AbilityActivityOff()
        {
            if (_mainHero.TryGetAbilityStorage(out Dictionary<AbilityTypes, Entity> abilityStorage))
            {
                foreach (KeyValuePair<AbilityTypes, Entity> item in abilityStorage)
                {
                    if(item.Value.TryGetAbilityActive(out ReactiveVariable<bool> abilityActive))
                        abilityActive.Value = false;
                }
            }
        }

        private void SetAbilityActiveOn(AbilityTypes abilityTipes)
        {
            if (_mainHero.TryGetAbilityStorage(out Dictionary<AbilityTypes, Entity> abilityStorage))
            {
                if(abilityStorage.ContainsKey(abilityTipes))
                    abilityStorage[abilityTipes].AbilityActive.Value = true;
            }
        }



    }
}
