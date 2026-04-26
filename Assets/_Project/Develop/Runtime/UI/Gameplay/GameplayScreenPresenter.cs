using Assets._Project.Develop.Runtime.UI.AbilityShop;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.HPBar;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private GameplayScreenView _gameplayScreenView;

        private readonly GameplayPresentersFactory _gameplayPresentersFactory;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        private EntitiesHealthDisplayPresenter _entitiesHealthDisplayPresenter;

        private AbilityPermanentDisplayPresenter _abilityPermanentDisplayPresenter;

        public GameplayScreenPresenter(
            GameplayScreenView gameplayScreenView,
            ProjectPresentersFactory projectPresentersFactory,
            GameplayPresentersFactory gameplayPresentersFactory)
        {
            _gameplayScreenView = gameplayScreenView;
            _projectPresentersFactory = projectPresentersFactory;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize()
        {

            CreateWallet();

            CreateEntitiesHealthDisplay();

            CreateAbilityPermanentDisplay();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();

            _childPresenters.Clear();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
        }

        public void LateUpdate()
        {
            _entitiesHealthDisplayPresenter.LateUpdate();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_gameplayScreenView.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void CreateEntitiesHealthDisplay()
        {
            _entitiesHealthDisplayPresenter = _gameplayPresentersFactory.CreateEntitiesHealthDisplayPresenter(_gameplayScreenView.EntitiesHealthDisplay);

            _childPresenters.Add(_entitiesHealthDisplayPresenter);
        }

        private void CreateAbilityPermanentDisplay()
        {
            _abilityPermanentDisplayPresenter = _gameplayPresentersFactory.CreateAbilityPermanentDisplayPresenter(_gameplayScreenView.IconListView);

            _childPresenters.Add(_abilityPermanentDisplayPresenter);
        }

    }
}
