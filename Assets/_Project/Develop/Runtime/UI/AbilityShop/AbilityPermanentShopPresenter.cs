using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.AbilityShop
{
    public class AbilityPermanentShopPresenter : PopupPresenterBase
    {
        private readonly AbilityPermanentShopView _view;

        private readonly ViewsFactory _viewsFactory;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private  WalletPresenter _walletPresenter;

        private readonly AbilityPermanentConfigsContainer _abilitiesContainer;

        private List<BuyAbilityPermanentPresenter> _buyAbilityPresenters = new();

        public AbilityPermanentShopPresenter(
            AbilityPermanentShopView view,
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            AbilityPermanentConfigsContainer abilitiesContainer)
        {
            _view = view;
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _abilitiesContainer = abilitiesContainer;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_view.CurrencyListView);
            _walletPresenter.Initialize();

            foreach(AbilityPermanentConfig abilityConfig in _abilitiesContainer.AbilityConfigs)
            {
                BuyAbilityView buyAbilityView = _viewsFactory.Create<BuyAbilityView>(ViewIDs.BuyAbilityView);
                _view.AbilityPermanentListView.Add(buyAbilityView);

                BuyAbilityPermanentPresenter buyAbilityPermanentPresenter = _projectPresentersFactory.CreateBuyAbilityPermanentPresenter(buyAbilityView, abilityConfig);
                _buyAbilityPresenters.Add(buyAbilityPermanentPresenter);
                buyAbilityPermanentPresenter.Initialize();
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (BuyAbilityPermanentPresenter presenter in _buyAbilityPresenters)
                presenter.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (BuyAbilityPermanentPresenter presenter in _buyAbilityPresenters)
            {
                presenter.Dispose();
                _view.AbilityPermanentListView.Remove(presenter.View);
                _viewsFactory.Release(presenter.View);
            }

            _buyAbilityPresenters.Clear();

            _walletPresenter.Dispose();
        }
    }
}
