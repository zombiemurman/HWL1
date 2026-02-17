using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Meta.MainMenu;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMeinMenuController);
            container.RegisterAsSingle(CreateStatisticsHandler);
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPopupService);
        }

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer container)
        {
            return new MainMenuPopupService(
                container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<MainMenuUIRoot>());
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container)
        {
            return new MainMenuPresentersFactory(container);
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            MainMenuUIRoot uiRoot = container.Resolve<MainMenuUIRoot>();

            MainMenuScreenView mainMenuScreenView = container
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);

            MainMenuScreenPresenter mainMenuScreenPresenter = container
                .Resolve<MainMenuPresentersFactory>()
                .CreateMainMenuScreenPresenter(mainMenuScreenView);

            return mainMenuScreenPresenter;
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

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            MainMenuUIRoot mainMenuUIRootPrefab = resourcesAssetsLoader
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }
    }
}
