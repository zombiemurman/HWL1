using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures
{
    public class StageFactory
    {
        private readonly DIContainer _container;

        public StageFactory(DIContainer container)
        {
            _container = container;
        }

        public IStage Create(StageConfig stageConfig)
        {
            switch(stageConfig)
            {
                case ClearAllEnemiesStageConfig clearAllEnemiesStageConfig:
                    return new ClearAllEnemiesStage(
                        clearAllEnemiesStageConfig,
                        _container.Resolve<EnemiesFactory>(),
                        _container.Resolve<EntitiesLifeContext>());

                default:
                    throw new ArgumentException($"Not supported {stageConfig.GetType()} type config");
            }
        }
    }
}
