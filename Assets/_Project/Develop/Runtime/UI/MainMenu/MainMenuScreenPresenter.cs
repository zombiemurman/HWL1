using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Statistics;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _mainMenuScreenView;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly StatisticsHandler _statisticsHandler;

        private readonly MainMenuPopupService _menuPopupService;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView mainMenuScreenView,
            ProjectPresentersFactory projectPresentersFactory,
            StatisticsHandler statisticsHandler,
            MainMenuPopupService menuPopupService)
        {
            _mainMenuScreenView = mainMenuScreenView;
            _projectPresentersFactory = projectPresentersFactory;
            _statisticsHandler = statisticsHandler;
            _menuPopupService = menuPopupService;
        }

        public void Initialize()
        {
            _mainMenuScreenView.ResetStatisticButtonClicked += OnResetStatisticButtonClicked;

            _statisticsHandler.EnoughtNo += OnEnoughtNo;

            CreateWallet();
            CreateStatistics();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _mainMenuScreenView.ResetStatisticButtonClicked -= OnResetStatisticButtonClicked;

            _statisticsHandler.EnoughtNo -= OnEnoughtNo;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateStatistics()
        {
            StatisticListPresenter statisticListPresenter = _projectPresentersFactory.CreateStatisticListPresenter(_mainMenuScreenView.StatisticsView);

            _childPresenters.Add(statisticListPresenter);
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_mainMenuScreenView.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void OnResetStatisticButtonClicked()
        {
            _statisticsHandler.Reset();
        }

        private void OnEnoughtNo()
        {
            _menuPopupService.OpenTextPopup("Нет денег для сброса статистики");
        }
    }
}
