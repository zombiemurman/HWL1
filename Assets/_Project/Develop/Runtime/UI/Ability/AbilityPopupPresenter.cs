using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Assets._Project.Develop.Runtime.UI.Ability
{
    public class AbilityPopupPresenter : PopupPresenterBase
    {
        private readonly AbilityPopupView _view;
        
        private readonly ViewsFactory _viewsFactory;

        private readonly GameplayPresentersFactory _presentersFactory;

        private AbilitiesConfigsContainer _configContainer;

        private List<SelectAbilityPresenter> _presenters = new();

        private TimerService _idleTimer;

        private List<IDisposable> _disposables = new();

        public AbilityPopupPresenter(
            AbilityPopupView view,
            AbilitiesConfigsContainer configContainer,
            GameplayPresentersFactory presentersFactory,
            ViewsFactory viewsFactory,
            TimerService idleTimer)
        {
            _view = view;
            _configContainer = configContainer;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _idleTimer = idleTimer;
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

                selectAbilityPresenter.Selected += OnPresenterSelected;

                selectAbilityPresenter.Initialize();

                _presenters.Add(selectAbilityPresenter);
            }

            _disposables.Add(_idleTimer.CurrentTime.Subscribe(OnCurrentTimeChanged));
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (SelectAbilityPresenter selectAbilityPresenter in _presenters)
            {
                selectAbilityPresenter.Selected -= OnPresenterSelected;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (SelectAbilityPresenter abilityPresenter in _presenters)
            {
                abilityPresenter.Selected -= OnPresenterSelected;
                _view.AbilityListView.Remove(abilityPresenter.View);
                _viewsFactory.Release(abilityPresenter.View);
                abilityPresenter.Dispose();
            }

            _presenters.Clear();

            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void OnCurrentTimeChanged(float arg1, float currentTime)
        {
            _view.SetTime(currentTime.ToString("0"));
        }

        private void OnPresenterSelected(SelectAbilityPresenter presenter)
        {
            _view.AbilityListView.Select(presenter.View);
        }
    }
}
