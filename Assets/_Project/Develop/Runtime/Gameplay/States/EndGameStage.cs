using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public abstract class EndGameStage : State
    {
        private readonly IInputService _inputService;

        protected EndGameStage(IInputService inputService)
        {
            _inputService = inputService;
        }

        public override void Enter()
        {
            base.Enter();

            _inputService.IsEnabled = false;
        }

        public override void Exit()
        {
            base.Exit();

            _inputService.IsEnabled = true;
        }
    }
}
