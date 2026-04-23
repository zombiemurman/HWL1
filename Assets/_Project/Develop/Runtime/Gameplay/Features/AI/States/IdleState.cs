using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.UI.Ability;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class IdleState : State, IUpdatableState
    {

        private readonly MainHeroHolderService _mainHeroHolderService;

        private readonly GameplayPopupService _popupService;

        private AbilityPopupPresenter _popup;

        public IdleState(
            MainHeroHolderService mainHeroHolderService, 
            GameplayPopupService popupService)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            _popup = _popupService.OpenAbilityPopup();
        }

        public override void Exit()
        {
            base.Exit();

            _popup?.Dispose();

            _mainHeroHolderService.SetExplosion();
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}
