using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.UI.Core;
using System;

namespace Assets._Project.Develop.Runtime.UI.Ability
{
    public class SelectAbilityPresenter : IPresenter
    {
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly CurrencyIconsConfig _currencyIconsConfig;

        public SelectAbilityPresenter(
            SelectAbillityView view,
            AbilityConfig abilityConfig,
            MainHeroHolderService mainHeroHolderService,
            CurrencyIconsConfig currencyIconsConfig)
        {
            View = view;
            AbilityConfig = abilityConfig;
            _mainHeroHolderService = mainHeroHolderService;
            _currencyIconsConfig = currencyIconsConfig;
        }

        public AbilityConfig AbilityConfig { get; }

        public SelectAbillityView View { get; }

        public void Initialize()
        {
            View.SetAbilityIcon(AbilityConfig.Icon);
            View.SetDescription(AbilityConfig.Description);
            View.SetPrice(AbilityConfig.Amount);
            View.SetCurrencyIcon(_currencyIconsConfig.GetSpriteFor(AbilityConfig.Currency));

            View.Click += OnViewClicked;
        }

        public void Dispose()
        {
            View.Click -= OnViewClicked;
        }

        private void OnViewClicked()
        {
            _mainHeroHolderService.SetAbilityBy(AbilityConfig.Ability);
        }

    }
}
