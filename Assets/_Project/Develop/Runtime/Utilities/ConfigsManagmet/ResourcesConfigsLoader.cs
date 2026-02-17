using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
            {typeof(StartWalletConfig), "Configs/Meta/Wallet/StartWalletConfig" },
            {typeof(PriceConfig), "Configs/Meta/PriceConfig" },
            {typeof(SetConfigurations), "Configs/GamePlay/SetConfigurations" },
            {typeof(CurrencyIconsConfig), "Configs/Meta/Wallet/CurrencyIconsConfig" },
        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);

                loadedConfigs.Add(configResourcesPath.Key, config);

                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}