using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Enemies
{
    public class EnemiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;

        private readonly BrainsFactory _brainsFacttory;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        public EnemiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFacttory = _container.Resolve<BrainsFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position, EntityConfig config)
        {
            Entity entity;

            switch(config)
            {
                case GhostConfig ghostConfig:
                    entity = _entitiesFactory.CreateBaseEntity(position, ghostConfig);
                    break;

                case CatapultConfig catapultConfig:
                    entity = _entitiesFactory.CreateCatapultEntity(position, catapultConfig);
                    _entitiesFactory.AddAbility(entity, AbilityTypes.Shoot, _entitiesFactory.CreateShootAbility(entity, catapultConfig.ShootAbilityConfig));
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            _entitiesLifeContext.Add(entity);

            return entity;
        }

    }
}
