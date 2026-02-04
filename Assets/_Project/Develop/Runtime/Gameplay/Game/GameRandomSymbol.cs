
using Assets._Project.Develop.Runtime.Gameplay.Config;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using System;
using System.Collections;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Game
{
    public class GameRandomSymbol
    {
        public event Action SymbolTrue;
        public event Action SymbolFalse;

        private ICoroutinesPerformer _coroutinesPerformer;

        private Coroutine _coroutine;

        private LevelConfig _levelConfig;

        public GameRandomSymbol(DIContainer container, LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;

            _coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
        }

        public bool IsRunning { get; private set; }

        public void Start() => IsRunning = true;

        public void Stop()
        {
            _coroutinesPerformer.StopPerform(AsyncUpdate());
            
            _coroutine = null;
            
            IsRunning = false;
        }

        public void Upadate()
        {
            if (IsRunning == false)
                return;


            if (_coroutine == null)
                _coroutine = _coroutinesPerformer.StartPerform(AsyncUpdate());
        }

        private IEnumerator AsyncUpdate()
        {
            string[] symbols = _levelConfig.Symbols;

            string symbol;

            int index;

            System.Random rnd = new System.Random();

            while (IsRunning)
            {
                index = rnd.Next(symbols.Length);
                symbol = symbols[index].ToUpper();

                Debug.Log($"Введи символ - {symbol}");

                yield return new WaitWhile(() => Input.anyKey == false);

                string pressedKey = Input.inputString.ToUpper();

                if (symbol == pressedKey)
                {
                    Debug.Log($"{symbol} = {pressedKey}");
                    SymbolTrue?.Invoke();
                }
                else
                {
                    Debug.Log($"{symbol} <> {pressedKey}");
                    SymbolFalse?.Invoke();
                }

                yield return new WaitForSeconds(1);
            }

        }
    }
}
