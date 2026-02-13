using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;

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
            container.RegisterAsSingle(CreateMetaHandler);
        }

        private static MetaHandler CreateMetaHandler(DIContainer container)
        {
            GameMode gameMode = container.Resolve<GameMode>();

            Statistics statistics = container.Resolve<Statistics>();

            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            StatisticsDataProvider statisticsDataProvider = container.Resolve<StatisticsDataProvider>();

            WalletService walletService = container.Resolve<WalletService>();

            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            SetConfigurations setConfigurations = configsProviderService.GetConfig<SetConfigurations>();

            return new MetaHandler(gameMode, statistics, playerDataProvider, statisticsDataProvider, coroutinesPerformer, walletService, setConfigurations.GetConfig(_args.TypeGame));
        }

        private static GameplayControllers CreateGameplayControllers(DIContainer container)
            => new GameplayControllers(container);

        private static Rules CreateRules(DIContainer container)
        {
            GameRandomSymbol gameRandomSymbol = container.Resolve<GameRandomSymbol>();

            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            SetConfigurations setConfigurations = configsProviderService.GetConfig<SetConfigurations>();

            return new Rules(gameRandomSymbol, setConfigurations.GetConfig(_args.TypeGame));
        }

        private static GameRandomSymbol CreateGameRandomSymbol(DIContainer container)
        {
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            SetConfigurations setConfigurations = configsProviderService.GetConfig<SetConfigurations>();

            return new GameRandomSymbol(container, setConfigurations.GetConfig(_args.TypeGame));
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
