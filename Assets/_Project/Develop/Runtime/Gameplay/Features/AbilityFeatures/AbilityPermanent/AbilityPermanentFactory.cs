using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class AbilityPermanentFactory
    {
        private DIContainer _container;

        public AbilityPermanentFactory(DIContainer container)
        {
            _container = container;
        }

        public AbilityPermanent CreateAbilityFor(Entity entity, AbilityPermanentConfig config)
        {
            switch(config)
            {
                case HealthAbilityConfig healthAbilityConfig:
                    return new HealthHeroAbility(
                        entity, 
                        healthAbilityConfig,
                        _container.Resolve<StageProviderService>());

                case DamageFirstEnemiesConfig damageFirstEnemiesConfig:
                    return new DamageFirstEnemiesAbility(
                        damageFirstEnemiesConfig,
                        _container.Resolve<EntitiesLifeContext>(),
                        _container.Resolve<StageProviderService>());

                case IncreaseExplosionDamageConfig incrementExplosionDamageConfig:
                    return new IncreaseExplosionDamageAbility(entity, incrementExplosionDamageConfig);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
