using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.MainMenu
{
    public class MeinMenuController
    {
        private DIContainer _container;

        public MeinMenuController(DIContainer container)
        {
            _container = container;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();

                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(TypeGame.Numbers)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();

                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(TypeGame.Characters)));
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Statistics statistics = _container.Resolve<Statistics>();
                WalletService walletService = _container.Resolve<WalletService>();


                Debug.Log($"Win - {statistics.WinCount}");
                Debug.Log($"Defeat - {statistics.DefeatCount}");

                Debug.Log("Золота в кошельке: " + walletService.GetCurrency(CurrencyTypes.Gold).Value);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StatisticsHandler statisticsHandler = _container.Resolve<StatisticsHandler>();
                statisticsHandler.Reset();
            }
        }

    }
}
