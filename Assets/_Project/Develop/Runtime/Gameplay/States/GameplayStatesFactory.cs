using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.features.Statistic;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class GameplayStatesFactory
    {
        private readonly DIContainer _container;

        private readonly TimerServiceFactory _timerServiceFactory;

        private readonly EntitiesFactory _entitiesFactory;

        public GameplayStatesFactory(DIContainer container)
        {
            _container = container;

            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public PreperationState CreatePreperationState()
        {
            return new PreperationState(_container.Resolve<PreperationTriggerService>());
        }

        public StageProcessState CreateStageProcessState()
        {
            return new StageProcessState(_container.Resolve<StageProviderService>());
        }

        public WinState CreateWinState(GameplayInputArgs gameplayInputArgs)
        {
            return new WinState(
                _container.Resolve<IInputService>(),
                _container.Resolve<StatisticsModel>(),
                _container.Resolve<StatisticsDataProvider>(),
                gameplayInputArgs,
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<StageProviderService>().LevelConfig.WinAmount);
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                _container.Resolve<IInputService>(),
                _container.Resolve<StatisticsModel>(),
                _container.Resolve<StatisticsDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public GameplayStateMachine CreateCoreLoopState()
        {
            List<IDisposable> disposables = new List<IDisposable>();

            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            BombSate bombState = new BombSate(
                _entitiesFactory, 
                _container.Resolve<WalletService>(),
                stageProviderService.LevelConfig.PriceBomb);

            TimerService idleTimer = _timerServiceFactory.Create(10f);
            disposables.Add(idleTimer);
            disposables.Add(bombState.Entered.Subscribe(idleTimer.Restart));

            StageProcessState stageProcessState = CreateStageProcessState();

            ICompositCondition bombToStageProcessCondition = new CompositeCondition()
                .Add(new FuncCondition(() => idleTimer.IsOver))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition stageProcessToBombCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Complited);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(bombState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(bombState, stageProcessState, bombToStageProcessCondition);
            coreLoopState.AddTransition(stageProcessState, bombState, stageProcessToBombCondition);

            return coreLoopState;
        }

        public GameplayStateMachine CreateGameplayStateMachine(GameplayInputArgs gameplayInputArgs)
        {
            //PreperationTriggerService preperationTriggerService = _container.Resolve<PreperationTriggerService>();

            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            MainHeroHolderService mainHeroHolderService = _container.Resolve<MainHeroHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();

            DefeatState defeatState = CreateDefeatState();

            WinState winState = CreateWinState(gameplayInputArgs);

            ICompositCondition coreLoopToWinStateCondition = new CompositeCondition()
                //.Add(new FuncCondition(() => preperationTriggerService.HasMainHeroContact.Value))
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Complited))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            ICompositCondition coreLoopToDefeatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() =>
                {
                    if(mainHeroHolderService.MainHero != null)
                        return mainHeroHolderService.MainHero.IsDead.Value; 

                    return false;
                }));

            GameplayStateMachine gameplayCycle = new GameplayStateMachine();

            gameplayCycle.AddState(coreLoopState);
            gameplayCycle.AddState(defeatState);
            gameplayCycle.AddState(winState);

            gameplayCycle.AddTransition(coreLoopState, winState, coreLoopToWinStateCondition);
            gameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeatStateCondition);

            return gameplayCycle;
        }
    }
}
