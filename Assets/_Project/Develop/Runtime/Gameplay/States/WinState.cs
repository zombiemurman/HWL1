using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class WinState : EndGameStage, IUpdatableState
    {
        private readonly GameplayInputArgs _gameplayInputArgs;

        private readonly StatisticsModel _statistics;
        private readonly StatisticsDataProvider _statisticsDataProvider;

        private readonly PlayerDataProvider _playerDataProvider;

        private readonly WalletService _walletService;

        private readonly SceneSwitcherService _sceneSwitcherService;

        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly int _winAmount;

        public WinState(
            IInputService inputService,
            StatisticsModel statistics,
            StatisticsDataProvider statisticsDataProvider,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            WalletService walletService,
            int winAmount) : base(inputService)
        {
            _statistics = statistics;
            _statisticsDataProvider = statisticsDataProvider;

            _playerDataProvider = playerDataProvider;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _winAmount = winAmount;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("WIN WIN WIN");

            _statistics.UpdateWin();

            _walletService.Add(CurrencyTypes.Gold, _winAmount);

            _coroutinesPerformer.StartPerform(_statisticsDataProvider.SaveAsync());
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void Update(float deltaTime)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }
    }
}
