using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using System;
using System.Collections;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle : IDisposable
    {
        private GameMode _gameMode;

        ICoroutinesPerformer _coroutinesPerformer;

        public GameplayCycle(GameMode gameMode, ICoroutinesPerformer coroutinesPerformer)
        {
            _gameMode = gameMode;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public IEnumerator Launch()
        {
            _gameMode.Win += OnGameModeWin;
            _gameMode.Defeat += OnGameModeDefeat;

            yield return new WaitForSeconds(1);

            _gameMode.Start();

            yield return null;
        }

        public void Update(float deltaTime) => _gameMode?.Update(deltaTime);

        public void Dispose()
        {
            OnGameModeEnded();
        }

        private void OnGameModeEnded()
        {
            if (_gameMode != null)
            {
                _gameMode.Win -= OnGameModeWin;
                _gameMode.Defeat -= OnGameModeDefeat;
            }
        }

        private void OnGameModeDefeat()
        {
            OnGameModeEnded();

            Debug.Log("Defeat");

            _coroutinesPerformer.StartPerform(Launch());
        }

        private void OnGameModeWin()
        {
            OnGameModeEnded();

            Debug.Log("Win");

            _coroutinesPerformer.StartPerform(Launch());
        }
    }
}
