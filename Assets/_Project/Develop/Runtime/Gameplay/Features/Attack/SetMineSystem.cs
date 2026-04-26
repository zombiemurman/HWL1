using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class SetMineSystem : IInitializableSystem, IDisposable
    {
        private ReactiveEvent<Vector3> _setMineRequest;

        private ICompositCondition _canSetMine;

        private EntitiesFactory _entitiesFactory;

        private IDisposable _setMineRequestDisposable;

        private readonly MineAbilityConfig _config;

        public SetMineSystem(
            EntitiesFactory entitiesFactory, MineAbilityConfig config)
        {
            _entitiesFactory = entitiesFactory;
            _config = config;
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
            if(_canSetMine.Evaluate())
                _entitiesFactory.CreateMine(positionMine, _config);
        }
    }
}
