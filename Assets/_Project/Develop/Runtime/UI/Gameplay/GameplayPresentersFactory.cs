using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView gameplayScreenView)
        {
            return new GameplayScreenPresenter(gameplayScreenView, this);
        }

        public GameplayRandomSymbolPresenter CreateGameplayRandomSymbolPresenter(GameplayRandomSymbolView view)
        {
            return new GameplayRandomSymbolPresenter(
                view, 
                _container.Resolve<GameRandomSymbol>(),
                _container.Resolve<GameplayPopupService>(),
                _container.Resolve<GameMode>());
        }

        public GameplayPresenter CreateGameplayPresenter(Transform viewParent)
        {
            return new GameplayPresenter(
                _container.Resolve<ViewsFactory>(),
               this,
               viewParent);
        }
    }
}
