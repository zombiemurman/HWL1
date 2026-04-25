using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.AbilityShop;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.TestPopup;
using Assets._Project.Develop.Runtime.UI.Core.TextPopup;
using Assets._Project.Develop.Runtime.UI.Statistics;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagmet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.UI
{
    public class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public AbilityPermanentShopPresenter CreateAbilityPermanentShopPresenter(AbilityPermanentShopView view)
        {
            return new AbilityPermanentShopPresenter(
                view,
                 _container.Resolve<ViewsFactory>(),
                 this,
                 _container.Resolve<ConfigsProviderService>().GetConfig<AbilityPermanentConfigsContainer>());
        }

        public BuyAbilityPermanentPresenter CreateBuyAbilityPermanentPresenter(
            BuyAbilityView view,
            AbilityPermanentConfig config)
        {
            return new BuyAbilityPermanentPresenter(
                view,
                _container.Resolve<AbilityPermanentProviderService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>(),
                config,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>());
        }

        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view,
            IReadOnlyVariable<int> currency,
            CurrencyTypes currencyType)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView iconTextListView)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                iconTextListView);
        }

        public StatisticPresenter CreateStatisticPresenter(string key, IReadOnlyVariable<int> value, TextTextView view)
        {
            return new StatisticPresenter(key, value, view);
        }

        public StatisticListPresenter CreateStatisticListPresenter(TextTextListView iconTextListView)
        {
            return new StatisticListPresenter(
                _container.Resolve<StatisticsModel>(),
                this,
                _container.Resolve<ViewsFactory>(),
                iconTextListView);
        }

        public TextPopupPresenter CreateTextPopupPresenter(TextPopupView view, string textPopup)
        {
            return new TextPopupPresenter(view, textPopup);
        }
    }
}
