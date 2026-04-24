using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.UI.Ability;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Develop.Runtime.Utilities.Timer;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class IdleState : State, IUpdatableState
    {

        private readonly MainHeroHolderService _mainHeroHolderService;

        private readonly GameplayPopupService _popupService;

        private TimerService _idleTimer;

        private AbilityPopupPresenter _popup;

        public IdleState(
            MainHeroHolderService mainHeroHolderService, 
            GameplayPopupService popupService,
            TimerService idleTimer)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _popupService = popupService;
            _idleTimer = idleTimer;
        }

        public override void Enter()
        {
            base.Enter();
            
            _popup = _popupService.OpenAbilityPopup(_idleTimer);
        }

        public override void Exit()
        {
            base.Exit();

            _popupService.ClosePopup(_popup);

            _mainHeroHolderService.SetExplosion();
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}
