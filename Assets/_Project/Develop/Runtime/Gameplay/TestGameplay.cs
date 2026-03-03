using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay
    {
        private DIContainer _container;

        private EntitiesFactory _entitiesFactory;

        private Entity _entity;

        private bool _isRunning;

        public TestGameplay(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void Run()
        {
            _isRunning = true;

            _entitiesFactory.CreateRigidbodyEntity(Vector3.zero + Vector3.forward * 5);

            _entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);
        }

        public void Update()
        {
            if (_isRunning == false) 
                return;

            EntityController();
        }

        private void ReleasedEntity()
        {
            if (_entity != null)
                _entitiesFactory.Release(_entity);
        }

        private void EntityController()
        {
            if (_entity == null)
                return;

            if(Input.GetKeyDown(KeyCode.Space))
                _entity.StartTeleportRequest.Invoke();
        }

    }
}
