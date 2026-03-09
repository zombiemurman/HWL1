using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeatures;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
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

            _entitiesFactory.CreateRigidbodyEntity(Vector3.zero + Vector3.forward * 6);

            _entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);
        }

        public void Update()
        {
            if (_isRunning == false) 
                return;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _entity.CurrentEnergy.Value = 100;

                _brainsFacttory.CreateBehaviourEntity_TeleportRandom(_entity);
            }    
                

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _entity.CurrentEnergy.Value = 100;

                _brainsFacttory.CreateBehaviourEntity_CurrentTargetTeleport(_entity, new MinHealthTargetSelector(_entity));
            }
                

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if(_entity != null)
                {
                    _entity.Dispose();
                    _entitiesFactory.Release(_entity);
                }

                _entity = _entitiesFactory.CreateHeroEntity(Vector3.zero);
                _brainsFacttory.CreateMainHeroBrain(_entity);
            }
        }
    }
}
