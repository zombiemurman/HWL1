using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Meta.MainMenu;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMeinMenuController);
            container.RegisterAsSingle(CreateStatisticsHandler);
        }

        private static MeinMenuController CreateMeinMenuController(DIContainer container)
            => new MeinMenuController(container);

        private static StatisticsHandler CreateStatisticsHandler(DIContainer container)
        {
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
            StatisticsDataProvider statisticsDataProvider = container.Resolve<StatisticsDataProvider>();

            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            PriceConfig priceConfig = configsProviderService.GetConfig<PriceConfig>();

            WalletService walletService = container.Resolve<WalletService>();

            return new StatisticsHandler(playerDataProvider, statisticsDataProvider, coroutinesPerformer, priceConfig, walletService);
        }
    }
}
