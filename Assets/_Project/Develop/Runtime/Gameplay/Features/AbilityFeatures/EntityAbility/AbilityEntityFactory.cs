using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility
{
    public class AbilityEntityFactory
    {
        private DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;

        public AbilityEntityFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public Entity CreateAbilytyBy(AbilityBaseConfig config)
        {
            switch(config)
            {
                case MineAbilityConfig mineAbilityConfig:
                    return _entitiesFactory.CreateInstallMineAbility(mineAbilityConfig);

                case PuddleAbilityConfig puddleAbilityConfig:
                    return _entitiesFactory.CreateInstallPuddleAbility(puddleAbilityConfig);

                case TurelAbilityConfig turelAbilityConfig:
                    return _entitiesFactory.CreateInstallTurelAbility(turelAbilityConfig);

                case ExplosionAbilityConfig explosionAbilityConfig:
                    return _entitiesFactory.CreateExplosionAbility(explosionAbilityConfig);

                default:
                    throw new ArgumentException();
            }
        }

    }
}
