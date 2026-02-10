using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Meta;
using System;
using System.Data;

namespace Assets._Project.Develop.Runtime.Gameplay.Game
{
    public class Rules : IDisposable
    {
        private GameRandomSymbol _randomSymbol;

        private LevelConfig _levelConfig;

        private int _countTrue;
        private int _countFalse;

        public bool Win {  get; private set; }
        public bool Defeat { get; private set; }

        public Rules(GameRandomSymbol gameRandomSymbol, LevelConfig levelConfig)
        {
            _randomSymbol = gameRandomSymbol;

            _levelConfig = levelConfig;

            _randomSymbol.SymbolTrue += OnSymboltrue;
            _randomSymbol.SymbolFalse += OnSymbolFalse;
        }

        public void Start()
        {
            _countTrue = 0;
            _countFalse = 0;

            Win = false;
            Defeat = false;
        }

        public void Update()
        {
            if(_levelConfig.EquallyWin <= _countTrue)
            {
                Win = true;
            }

            if (_levelConfig.NoEquallyDefeat <= _countFalse)
            {
                Defeat = true;
            }
        }

        private void OnSymbolFalse()
        {
            _countFalse++;
        }

        private void OnSymboltrue()
        {
            _countTrue++;
        }

        public void Dispose()
        {
            _randomSymbol.SymbolTrue -= OnSymboltrue;
            _randomSymbol.SymbolFalse -= OnSymbolFalse;
        }

    }
}
