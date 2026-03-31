using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class IdleState : State, IUpdatableState
    {

        private readonly MainHeroHolderService _mainHeroHolderService;

        public IdleState(MainHeroHolderService mainHeroHolderService)
        {
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            _mainHeroHolderService.SetMine(true);
            _mainHeroHolderService.SetExplosion(false);
        }

        public override void Exit()
        {
            base.Exit();

            _mainHeroHolderService.SetMine(false);
            _mainHeroHolderService.SetExplosion(true);
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}
