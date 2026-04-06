using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameStage, IUpdatableState
    {

        private readonly SceneSwitcherService _sceneSwitcherService;

        private readonly StatisticsModel _statistics;
        private readonly StatisticsDataProvider _statisticsDataProvider;

        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly GameplayPopupService _gameplayPopupService;

        public DefeatState(
            IInputService inputService,
            StatisticsModel statistics,
            StatisticsDataProvider statisticsDataProvider,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            GameplayPopupService gameplayPopupService) : base(inputService)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;

            _statistics = statistics;
            _statisticsDataProvider = statisticsDataProvider;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("DEFEAT DEFEAT DEFEAT");

            _statistics.UpdateDefeat();

            _coroutinesPerformer.StartPerform(_statisticsDataProvider.SaveAsync());

            _gameplayPopupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            //}
        }
    }
}
