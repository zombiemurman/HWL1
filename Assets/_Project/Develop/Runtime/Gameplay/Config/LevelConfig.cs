using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Config
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public TypeGame TypeGame { get; private set; }
        [field: SerializeField] public string[] Symbols { get; private set; }
        [field: SerializeField] public int EquallyWin { get; private set; }
        [field: SerializeField] public int NoEquallyDefeat { get; private set; }

        [field: SerializeField] private List<CurrencyConfig> _valuesWin;
        
        [field: SerializeField] private List<CurrencyConfig> _valuesDefeat;

        public int GetValueWinFor(CurrencyTypes currencyTypes)
           => _valuesWin.First(config => config.Type == currencyTypes).Value;

        public int GetValueDefeatFor(CurrencyTypes currencyTypes)
           => _valuesDefeat.First(config => config.Type == currencyTypes).Value;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyTypes Type { get; private set; }
            [field: SerializeField] public int Value { get; private set; }
        }
    }
}
