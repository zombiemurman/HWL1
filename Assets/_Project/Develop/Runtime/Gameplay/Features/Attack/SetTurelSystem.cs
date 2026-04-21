using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class SetTurelSystem : IInitializableSystem, IDisposable
    {
        private readonly BrainsFactory _brainsFactory;

        private ReactiveEvent<Vector3> _setMineRequest;

        private ICompositCondition _canSetMine;

        private EntitiesFactory _entitiesFactory;

        private IDisposable _setMineRequestDisposable;

        public SetTurelSystem(
            EntitiesFactory entitiesFactory, BrainsFactory brainsFactory)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFactory = brainsFactory;
        }

        public void OnInit(Entity entity)
        {
            _canSetMine = entity.CanSetMine;
            _setMineRequest = entity.SetMineRequest;

            _setMineRequestDisposable = _setMineRequest.Subscribe(OnSetMine);
        }

        public void Dispose()
        {
            _setMineRequestDisposable.Dispose();
        }

        private void OnSetMine(Vector3 positionMine)
        {
            if (_canSetMine.Evaluate())
            {
                Entity entity = _entitiesFactory.CreateTurel(positionMine);
                _brainsFactory.CreateMTurelBrain(entity, new NearestDamageableTargetSelector(entity));
            }
                
        }
    }
}
