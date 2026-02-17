using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private GameplayScreenView _gameplayScreenView;
        private GameplayPresentersFactory _gameplayPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(GameplayScreenView gameplayScreenView, GameplayPresentersFactory gameplayPresentersFactory)
        {
            _gameplayScreenView = gameplayScreenView;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize()
        {
            CreateGameplay();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();

            _childPresenters.Clear();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
        }

        private void CreateGameplay()
        {
            GameplayPresenter gameplayPresenter = _gameplayPresentersFactory.CreateGameplayPresenter(_gameplayScreenView.Gameplay);

            _childPresenters.Add(gameplayPresenter);
        }
    }
}
