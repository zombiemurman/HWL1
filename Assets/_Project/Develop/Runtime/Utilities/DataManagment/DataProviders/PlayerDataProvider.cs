using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.Data;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {

        private readonly ConfigsProviderService _configProviderService;

        public PlayerDataProvider(
            ISaveLoadService saveLoadService, 
            ConfigsProviderService configProviderService) : base(saveLoadService)
        {
            _configProviderService = configProviderService;
        }

        protected override PlayerData GetOriginData()
        {
           return new PlayerData()
           {
               WalletData = InitWalletData(),
           };
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            StartWalletConfig walletConfig = _configProviderService.GetConfig<StartWalletConfig>();

            foreach (CurrencyTypes currencyTypes in Enum.GetValues(typeof(CurrencyTypes)))
                walletData[currencyTypes] = walletConfig.GetValueFor(currencyTypes);

            return walletData;
        }
    }
}
