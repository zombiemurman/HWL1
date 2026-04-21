using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHero
{
    public class MainHeroFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;

        private readonly BrainsFactory _brainsFacttory;

        private readonly ConfigsProviderService _configsProviderService;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MainHeroHolderService _mainHeroHolderService;


        public MainHeroFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFacttory = _container.Resolve<BrainsFactory>();
            _configsProviderService = _container.Resolve<ConfigsProviderService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();

            _mainHeroHolderService = _container.Resolve<MainHeroHolderService>();
        }

        public Entity Create(Vector3 position, int levelNumber)
        {
            HeroConfig config = _configsProviderService.GetConfig<LevelsListConfig>().GetBy(levelNumber).HeroConfig;

            Entity entity = _entitiesFactory.CreateHeroEntity(position, config);

            _entitiesFactory.AddAbility(entity, AbilityTipes.Explosion, _entitiesFactory.CreateExplosionAbility());
            _entitiesFactory.AddAbility(entity, AbilityTipes.Mine, _entitiesFactory.CreateInstallMineAbility());
            _entitiesFactory.AddAbility(entity, AbilityTipes.Turret, _entitiesFactory.CreateInstallTurelAbility());

            _entitiesLifeContext.Add(entity);

            _brainsFacttory.CreateExplosionBrain(entity);

            return entity;
        }
    }
}
