using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay
    {
        private EntitiesFactory _entitiesFactory;

        private BrainsFactory _brainsFacttory;

        private Entity _entity;

        private bool _isRunning;

        public TestGameplay(
            EntitiesFactory entitiesFactory,
            BrainsFactory brainsFactory)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFacttory = brainsFactory;
        }

        public void Run()
        {
            _isRunning = true;

            CreateEnemy();

            //_brainsFacttory.CreateBombExplosionBrain(_entitiesFactory.CreateHeroEntity());

        }

        public void Update()
        {
            if (_isRunning == false) 
                return;


            if(Input.GetKeyDown(KeyCode.E))
                CreateEnemy();

        }

        private void CreateEnemy()
        {
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(5, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(4, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(3, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(2, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(1, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(0, 0, 5));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(-1, 0, 5));
        }
    }
}
