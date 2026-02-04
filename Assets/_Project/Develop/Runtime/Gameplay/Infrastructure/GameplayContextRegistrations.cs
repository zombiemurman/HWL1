using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        private static GameplayInputArgs _args;

        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            _args = args;

            container.RegisterAsSingle(CreateGameMode);
            container.RegisterAsSingle(CreatGameplayCycle);
            container.RegisterAsSingle(CreateGameRandomSymbol);
            container.RegisterAsSingle(CreateRules);
            container.RegisterAsSingle(CreateGameplayControllers);
        }

        private static GameplayControllers CreateGameplayControllers(DIContainer container)
            => new GameplayControllers(container);

        private static Rules CreateRules(DIContainer container)
        {
            GameRandomSymbol gameRandomSymbol = container.Resolve<GameRandomSymbol>();

            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            LevelConfig levelConfig = GetLevelConfig(resourcesAssetsLoader);

            return new Rules(gameRandomSymbol, levelConfig);
        }

        private static GameRandomSymbol CreateGameRandomSymbol(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            LevelConfig levelConfig = GetLevelConfig(resourcesAssetsLoader);

            return new GameRandomSymbol(container, levelConfig);
        }

        private static LevelConfig GetLevelConfig(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            LevelConfig levelConfig;

            switch (_args.TypeGame)
            {
                case TypeGame.Numbers:
                    levelConfig = resourcesAssetsLoader.Load<LevelConfig>("Configs/LevelConfigNumbers");
                    break;

                case TypeGame.Characters:
                    levelConfig = resourcesAssetsLoader.Load<LevelConfig>("Configs/LevelConfigSymbols");
                    break;

                default:
                    throw new ArgumentException("Не определены настройки для ", nameof(_args.TypeGame));
            }

            return levelConfig;
        }

        private static GameplayCycle CreatGameplayCycle(DIContainer container)
        {
            GameMode gameMode = container.Resolve<GameMode>();
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

            return new GameplayCycle(gameMode, coroutinesPerformer);
        }

        private static GameMode CreateGameMode(DIContainer container)
        {
            GameRandomSymbol gameRandomSymbol = container.Resolve<GameRandomSymbol>();

            Rules rules = container.Resolve<Rules>();

            return new GameMode(rules, gameRandomSymbol);
        }    

        
    }
}
