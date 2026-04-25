using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Runtime.UI.AbilityShop
{
    public class BuyAbilityPermanentPresenter : IPresenter
    {
        private BuyAbilityView _view;

        private AbilityPermanentProviderService _abilityPermanentProviderService;

        private WalletService _walletService;

        private PlayerDataProvider _playerDataProvider;

        private ICoroutinesPerformer _coroutinesPerformer;

        private AbilityPermanentConfig _abilityPermanentConfig;

        private CurrencyIconsConfig _currencyIconsConfig;

        private List<IDisposable> _disposables = new();

        public BuyAbilityPermanentPresenter(
            BuyAbilityView view,
            AbilityPermanentProviderService abilityPermanentProviderService,
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            AbilityPermanentConfig abilityPermanentConfig,
            CurrencyIconsConfig currencyIconsConfig)
        {
            _view = view;
            _abilityPermanentProviderService = abilityPermanentProviderService;
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _abilityPermanentConfig = abilityPermanentConfig;
            _currencyIconsConfig = currencyIconsConfig;
        }

        public BuyAbilityView View => _view;

        public void Initialize()
        {
            _view.Initialize(_abilityPermanentConfig.Icon, _abilityPermanentConfig.Description);

            UpdateBuyButtonState();

            _view.BuyButtonView.Click += OnBuyButtonClicked;

            IReadOnlyVariable<int> currency = _walletService.GetCurrency(_abilityPermanentConfig.Currency);
            _disposables.Add(currency.Subscribe(OnWalletChanged));
        }

        public void Dispose()
        {
            _view.BuyButtonView.Click -= OnBuyButtonClicked;

            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void UpdateBuyButtonState()
        {
            _view.BuyButtonView.SetPriceText(_abilityPermanentConfig.Price.ToString());
            _view.BuyButtonView.SetIcon(_currencyIconsConfig.GetSpriteFor(_abilityPermanentConfig.Currency));

            if (_abilityPermanentProviderService.AbilitiesPermanentsID.Contains(_abilityPermanentConfig.ID))
            {
                _view.BuyButtonView.Lock();
            }
            else if(_walletService.Enought(_abilityPermanentConfig.Currency, _abilityPermanentConfig.Price))
            {
                _view.BuyButtonView.Unlock();
            }
            else
            {
                _view.BuyButtonView.UnlockPrice();
            }
        }

        private void OnBuyButtonClicked()
        {
            if (_abilityPermanentProviderService.AbilitiesPermanentsID.Contains(_abilityPermanentConfig.ID))
                return;
            
            if (_walletService.Enought(_abilityPermanentConfig.Currency, _abilityPermanentConfig.Price))
            {
                _abilityPermanentProviderService.Add(_abilityPermanentConfig.ID);

                _walletService.Spend(_abilityPermanentConfig.Currency, _abilityPermanentConfig.Price);

                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
            }
        }

        private void OnWalletChanged(int arg1, int arg2) => UpdateBuyButtonState();

    }
}
