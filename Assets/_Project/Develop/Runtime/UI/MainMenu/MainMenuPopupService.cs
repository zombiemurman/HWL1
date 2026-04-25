using Assets._Project.Develop.Runtime.UI.AbilityShop;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUIRoot _uiRoot;

        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory,
            MainMenuUIRoot uiRoot) : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public AbilityPermanentShopPresenter OpenShopPopup(Action closedCallback = null)
        {
            AbilityPermanentShopView view = ViewsFactory.Create<AbilityPermanentShopView>(ViewIDs.AbilityPermanentShopView, PopupLayer);

            AbilityPermanentShopPresenter popup = PresentersFactory.CreateAbilityPermanentShopPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }
    }
}
