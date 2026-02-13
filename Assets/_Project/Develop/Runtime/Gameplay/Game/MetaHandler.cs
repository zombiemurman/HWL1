using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Game
{
    internal class MetaHandler : IDisposable
    {
        private GameMode _gameMode;

        private Statistics _statistics;

        private PlayerDataProvider _playerDataProvider;

        private StatisticsDataProvider _statisticsDataProvider;

        private ICoroutinesPerformer _coroutinesPerformer;

        private WalletService _walletService;

        private LevelConfig _levelConfig;

        public MetaHandler(
            GameMode gameMode, 
            Statistics statistics, 
            PlayerDataProvider playerDataProvider,
            StatisticsDataProvider statisticsDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            WalletService walletService,
            LevelConfig levelConfig)
        {
            _gameMode = gameMode;
            _statistics = statistics;
            _playerDataProvider = playerDataProvider;
            _statisticsDataProvider = statisticsDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _levelConfig = levelConfig;
        }

        public void Initialize()
        {
            _gameMode.Win += OnGameModeWin;
            _gameMode.Defeat += OnGameModeDefeat;
        }

        public void Dispose()
        {
            _gameMode.Win -= OnGameModeWin;
            _gameMode.Defeat -= OnGameModeDefeat;
        }

        private void OnGameModeDefeat()
        {
            _statistics.UpdateDefeat();

            foreach (CurrencyTypes currencyTypes in Enum.GetValues(typeof(CurrencyTypes)))
                _walletService.Spend(currencyTypes, _levelConfig.GetValueDefeatFor(currencyTypes));

            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            _coroutinesPerformer.StartPerform(_statisticsDataProvider.Save());
        }

        private void OnGameModeWin()
        {
            _statistics.UpdateWin();

            foreach (CurrencyTypes currencyTypes in Enum.GetValues(typeof(CurrencyTypes)))
                _walletService.Add(currencyTypes, _levelConfig.GetValueWinFor(currencyTypes));

            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            _coroutinesPerformer.StartPerform(_statisticsDataProvider.Save());
        }
    }
}
