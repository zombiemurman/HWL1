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
        }

        public void Update()
        {
            if (_isRunning == false) 
                return;

            CreateCharacterControllerEntity();

            CreateRigidbodyEntity();

            EntityController();
        }

        private void ReleasedEntity()
        {
            if (_entity != null)
                _entitiesFactory.Release(_entity);
        }

        private void CreateCharacterControllerEntity()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ReleasedEntity();

                _entity = _entitiesFactory.CreateCharacterControllerEntity(Vector3.zero);
            }
        }

        private void CreateRigidbodyEntity()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ReleasedEntity();

                _entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);
            }
        }

        private void EntityController()
        {
            if (_entity == null)
                return;

            Vector3 input = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0,
                Input.GetAxisRaw("Vertical"));

            _entity.MoveDirection.Value = input;
        }

    }
}
