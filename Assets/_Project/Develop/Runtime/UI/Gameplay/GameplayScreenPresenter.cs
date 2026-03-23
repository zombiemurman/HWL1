using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private GameplayScreenView _gameplayScreenView;
        
        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView gameplayScreenView, 
            ProjectPresentersFactory projectPresentersFactory)
        {
            _gameplayScreenView = gameplayScreenView;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {

            CreateWallet();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();

            _childPresenters.Clear();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_gameplayScreenView.WalletView);

            _childPresenters.Add(walletPresenter);
        }

    }
}
