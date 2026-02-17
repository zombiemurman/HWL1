using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresenter : IPresenter
    {
        private readonly ViewsFactory _viewsFactory;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;

        private GameplayRandomSymbolPresenter _gameplayRandomSymbolPresenter;
        private GameplayRandomSymbolView _gameplayRandomSymbolView;

        private Transform _parent;

        public GameplayPresenter(ViewsFactory viewsFactory, GameplayPresentersFactory gameplayPresentersFactory, Transform parent)
        {
            _viewsFactory = viewsFactory;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _parent = parent;
        }

        public void Initialize()
        {
            _gameplayRandomSymbolView = _viewsFactory.Create<GameplayRandomSymbolView>(ViewIDs.GameplayRandomSymbol, _parent);

            _gameplayRandomSymbolPresenter = _gameplayPresentersFactory.CreateGameplayRandomSymbolPresenter(_gameplayRandomSymbolView);

            _gameplayRandomSymbolPresenter.Initialize();
        }

        public void Dispose()
        {
            _viewsFactory.Release(_gameplayRandomSymbolView);
            _gameplayRandomSymbolPresenter.Dispose();
        }
    }
}
