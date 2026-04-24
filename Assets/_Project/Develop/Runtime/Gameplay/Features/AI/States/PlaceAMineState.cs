using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{

    public class PlaceAMineState : State, IUpdatableState
    {
        private readonly WalletService _walletService; 

        private ReactiveEvent<Vector3> _setMineRequest;

        private ReactiveVariable<bool> _abilityActive;

        private IInputService _inputService;

        private int _priceMine;

        public PlaceAMineState(
            Entity entity, 
            IInputService inputService, 
            WalletService walletService, 
            int priceMine)
        {
            Entity installMineAbility = entity.AbilityStorage[AbilityTypes.Puddle];

            _setMineRequest = installMineAbility.SetMineRequest;
            _abilityActive = installMineAbility.AbilityActive;

            _inputService = inputService;
            _walletService = walletService;
            _priceMine = priceMine;
        }

        public void Update(float deltaTime)
        {
            if (_abilityActive.Value == false)
                return;

            if (_inputService.Direction != Vector3.zero)
            {
                if (_walletService.Enought(CurrencyTypes.Gold, _priceMine) == false)
                    return;

                _setMineRequest.Invoke(_inputService.Direction);

                _walletService.Spend(CurrencyTypes.Gold, _priceMine);
            }
        }
    }
}
