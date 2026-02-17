using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;


namespace Assets._Project.Develop.Runtime.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _iconTextListView;

        private readonly List<CurrencyPresenter> _currenciesPresenter = new();

        public WalletPresenter(
            WalletService walletService,
            ProjectPresentersFactory projectPresentersFactory,
            ViewsFactory viewsFactory,
            IconTextListView iconTextListView)
        {
            _walletService = walletService;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _iconTextListView = iconTextListView;
        }

        public void Initialize()
        {
            foreach (CurrencyTypes currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView);

                _iconTextListView.Add(currencyView);

                CurrencyPresenter currencyPresenter = _projectPresentersFactory.CreateCurrencyPresenter(
                    currencyView,
                    _walletService.GetCurrency(currencyType),
                    currencyType);

                currencyPresenter.Initialize();

                _currenciesPresenter.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currenciesPresenter)
            {
                _iconTextListView.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }

            _currenciesPresenter.Clear();
        }
    }
}
