using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta
{
    [CreateAssetMenu(menuName = "Configs/Meta/PriceConfig", fileName = "PriceConfig")]
    public class PriceConfig : ScriptableObject
    {
        [SerializeField] private CurrencyConfig PriceToReset;

        public Dictionary<CurrencyTypes, int> GetPriceToReset()
        {
            Dictionary<CurrencyTypes, int> priceToReset = new()
            {
                {PriceToReset.Type, PriceToReset.Value },
            };

            return priceToReset;
        }
            

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyTypes Type { get; private set; }
            [field: SerializeField] public int Value { get; private set; }
        }
    }
}
