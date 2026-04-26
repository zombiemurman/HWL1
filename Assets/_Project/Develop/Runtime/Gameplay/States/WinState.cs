using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Gameplay;
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

        private readonly GameplayPopupService _gameplayPopupService;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly int _winAmountGold;
        private readonly int _winAmountDiamond;

        public WinState(
            IInputService inputService,
            StatisticsModel statistics,
            StatisticsDataProvider statisticsDataProvider,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            WalletService walletService,
            int winAmount,
            int winAmountDiamond,
            GameplayPopupService gameplayPopupService,
            EntitiesLifeContext entitiesLifeContext) : base(inputService)
        {
            _statistics = statistics;
            _statisticsDataProvider = statisticsDataProvider;

            _playerDataProvider = playerDataProvider;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _winAmountGold = winAmount;
            _winAmountDiamond = winAmountDiamond;
            _gameplayPopupService = gameplayPopupService;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("WIN WIN WIN");

            _entitiesLifeContext.ReleaseAll();

            _statistics.UpdateWin();

            _walletService.Add(CurrencyTypes.Gold, _winAmountGold);
            _walletService.Add(CurrencyTypes.Diamond, _winAmountDiamond);

            _coroutinesPerformer.StartPerform(_statisticsDataProvider.SaveAsync());
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _gameplayPopupService.OpenWinPopup();
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
