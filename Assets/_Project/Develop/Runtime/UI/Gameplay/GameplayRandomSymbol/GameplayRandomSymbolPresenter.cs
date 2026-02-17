using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using System;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol
{
    public class GameplayRandomSymbolPresenter : IPresenter
    {
        private readonly GameplayRandomSymbolView _view;

        private readonly GameRandomSymbol _gameRandomSymbol;

        private readonly GameMode _gameMode;

        private readonly GameplayPopupService _gameplayPopupService;

        public GameplayRandomSymbolPresenter(
            GameplayRandomSymbolView view,
            GameRandomSymbol gameRandomSymbol,
            GameplayPopupService gameplayPopupService,
            GameMode gameMode)
        {
            _view = view;
            _gameRandomSymbol = gameRandomSymbol;
            _gameplayPopupService = gameplayPopupService;
            _gameMode = gameMode;
        }

        public void Initialize()
        {
            _view.SetTextAI("");
            _view.SetTextPlayer("");

            _gameRandomSymbol.SymbolAI += OnSymbolAiChanged;
            _gameRandomSymbol.SymbolPlayer += OnSymbolPlayerChanged;

            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;

        }

        public void Dispose()
        {
            _gameRandomSymbol.SymbolAI -= OnSymbolAiChanged;
            _gameRandomSymbol.SymbolPlayer -= OnSymbolPlayerChanged;

            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }

        private void OnSymbolPlayerChanged(string symbol)
        {
            _view.SetTextPlayer(symbol);
        }

        private void OnSymbolAiChanged(string symbol)
        {
            _view.SetTextAI(symbol);
        }

        private void OnDefeat()
        {
            _gameplayPopupService.OpenTextPopup("Defeat");
        }

        private void OnWin()
        {
            _gameplayPopupService.OpenTextPopup("WIN");
        }
    }
}
