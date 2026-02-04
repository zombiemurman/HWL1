using Assets._Project.Develop.Runtime.Gameplay.Game;
using System;


namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameMode
    {
        public event Action Win;
        public event Action Defeat;

        private GameRandomSymbol _randomSymbol;
        private Rules _rules;

        private bool _isRunning;

        public GameMode(Rules rules, GameRandomSymbol randomSymbol)
        {
            _rules = rules;
            _randomSymbol = randomSymbol;
        }

        public bool IsRunning => _isRunning;

        public void Start()
        {
            _isRunning = true;

            _randomSymbol.Start();

            _rules.Start();
        }

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;

            if (DefeatConditionCompleted())
            {
                ProcessDefeat();
                return;
            }

            if (WinConditionCompleted())
            {
                ProcessWin();
                return;
            }
        }

        private bool DefeatConditionCompleted()
        {
            return _rules.Defeat;
        }

        private bool WinConditionCompleted()
        {
            return _rules.Win;
        }

        private void ProcessEndGame()
        {
            _isRunning = false;
            _randomSymbol.Stop();
        }

        private void ProcessDefeat()
        {
            ProcessEndGame();
            Defeat?.Invoke();
        }

        private void ProcessWin()
        {
            ProcessEndGame();
            Win?.Invoke();
        }
    }
}
