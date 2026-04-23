using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Ability
{
    public class AbilityPopupPresenter : PopupPresenterBase
    {
        private readonly AbilityPopupView _view;
        
        private readonly ViewsFactory _viewsFactory;

        private readonly GameplayPresentersFactory _presentersFactory;

        private AbilitiesConfigsContainer _configContainer;

        private List<SelectAbilityPresenter> _presenters = new();

        public AbilityPopupPresenter(
            AbilityPopupView view,
            AbilitiesConfigsContainer configContainer,
            GameplayPresentersFactory presentersFactory,
            ViewsFactory viewsFactory)
        {
            _view = view;
            _configContainer = configContainer;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            foreach(AbilityConfig abilityConfig in _configContainer.AbilityConfigs)
            {
                SelectAbillityView selectAbillityView = _viewsFactory.Create<SelectAbillityView>(ViewIDs.SelectAbillityView);
                
                _view.AbilityListView.Add(selectAbillityView);

                SelectAbilityPresenter selectAbilityPresenter = _presentersFactory.CreateSelectAbilityPresenter(selectAbillityView, abilityConfig);

                selectAbilityPresenter.Initialize();

                _presenters.Add(selectAbilityPresenter);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (SelectAbilityPresenter abilityPresenter in _presenters)
            {
                _view.AbilityListView.Remove(abilityPresenter.View);
                _viewsFactory.Release(abilityPresenter.View);
                abilityPresenter.Dispose();
            }

            _presenters.Clear();
        }
    }
}
