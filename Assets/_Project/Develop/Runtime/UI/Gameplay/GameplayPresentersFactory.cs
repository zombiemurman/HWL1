using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.Ability;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol;
using Assets._Project.Develop.Runtime.UI.Gameplay.ResultsPopups;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _gameplayInputArgs;

        public GameplayPresentersFactory(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView gameplayScreenView)
        {
            return new GameplayScreenPresenter(gameplayScreenView, _container.Resolve<ProjectPresentersFactory>());
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

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
        {
            return new WinPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<SceneSwitcherService>());
        }

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
        {
            return new DefeatPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<SceneSwitcherService>(),
                _gameplayInputArgs);
        }

        public SelectAbilityPresenter CreateSelectAbilityPresenter(
            SelectAbillityView view,
            AbilityConfig abilityConfig)
        {
            return new SelectAbilityPresenter(
               view,
               abilityConfig,
               _container.Resolve<MainHeroHolderService>(),
               _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>());
        }

        public AbilityPopupPresenter CreateAbilityPopupPresenter(AbilityPopupView view)
        {
            return new AbilityPopupPresenter(
                view,
                _container.Resolve<ConfigsProviderService>().GetConfig<AbilitiesConfigsContainer>(),
                this,
                _container.Resolve<ViewsFactory>());
        }
    }
}
