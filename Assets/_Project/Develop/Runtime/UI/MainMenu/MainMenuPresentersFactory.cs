using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using System;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView mainMenuScreenView)
        {
            return new MainMenuScreenPresenter(
                mainMenuScreenView,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<StatisticsHandler>(),
                _container.Resolve<MainMenuPopupService>());
        }
    }
}
