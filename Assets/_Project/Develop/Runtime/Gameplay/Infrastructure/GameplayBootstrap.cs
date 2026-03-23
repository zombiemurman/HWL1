using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.States;
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


        private EntitiesLifeContext _entitiesLifeContext;

        private AIBrainsContext _brainsContext;

        private GameplayStatesContext _gameplayStatesContext;

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
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();

            _brainsContext = _container.Resolve<AIBrainsContext>();

            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            _container.Resolve<MainHeroFactory>().Create(Vector3.zero, _inputArgs.LevelNumber);

            yield break;
        }

        public override void Run()
        {
            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _brainsContext?.Update(Time.deltaTime);

            _entitiesLifeContext?.Update(Time.deltaTime);

            _gameplayStatesContext?.Update(Time.deltaTime);

        }

        private void OnDestroy()
        {
            _entitiesLifeContext.Dispose();
        }
    }
}
