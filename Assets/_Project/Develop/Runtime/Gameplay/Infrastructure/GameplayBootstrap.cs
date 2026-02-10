using Assets._Project.Develop.Runtime.Gameplay.Game;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;

        private GameplayCycle _gameplayCycle;

        private GameRandomSymbol _randomSymbol;

        private GameplayControllers _gameplayControllers;

        private Rules _rules;

        private MetaHandler _metaHandler;

        private ICoroutinesPerformer _coroutinesPerformer;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();

            _gameplayCycle = _container.Resolve<GameplayCycle>();

            _randomSymbol = _container.Resolve<GameRandomSymbol>();

            _rules = _container.Resolve<Rules>();

            _gameplayControllers = _container.Resolve<GameplayControllers>();

            _metaHandler = _container.Resolve<MetaHandler>();
            _metaHandler.Initialize();

            yield break;
        }

        public override void Run()
        {
            _coroutinesPerformer.StartPerform(_gameplayCycle.Launch());
        }

        private void Update()
        {
            _rules?.Update();

            _gameplayCycle?.Update(Time.deltaTime);

            _randomSymbol?.Upadate();

            _gameplayControllers?.Update();
        }

        private void OnDestroy()
        {
            _metaHandler.Dispose();

            _randomSymbol.Stop();

            _rules?.Dispose();
        }
    }
}
