using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.features.Statistic
{
    public class StatisticsHandler
    {
        private PlayerDataProvider _playerDataProvider;

        private StatisticsDataProvider _statisticsDataProvider;

        private ICoroutinesPerformer _coroutinesPerformer;

        private PriceConfig _priceConfig;

        private WalletService _walletService;

        public StatisticsHandler(
            PlayerDataProvider playerDataProvider, 
            StatisticsDataProvider statisticsDataProvider, 
            ICoroutinesPerformer coroutinesPerformer, 
            PriceConfig priceConfig, 
            WalletService walletService)
        {
            _playerDataProvider = playerDataProvider;
            _statisticsDataProvider = statisticsDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _priceConfig = priceConfig;
            _walletService = walletService;
        }

        public void Reset()
        {
            Dictionary<CurrencyTypes, int> priceToReset = _priceConfig.GetPriceToReset();

            foreach (KeyValuePair<CurrencyTypes, int> price in priceToReset)
            {
                if (_walletService.Enought(price.Key, price.Value))
                {
                    _walletService.Spend(price.Key, price.Value);

                    _statisticsDataProvider.Reset();

                    _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                    _coroutinesPerformer.StartPerform(_statisticsDataProvider.Save());

                    Debug.Log("Прогресс сброшен");
                }
                else
                {
                    Debug.Log($"Не хвататает {price.Key} для сброса прогресса игры");
                }
            }
        }
    }
}
