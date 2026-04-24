using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class AbilityIdleState : State, IUpdatableState
    {
        private readonly WalletService _walletService;

        private readonly MainHeroHolderService _mainHeroHolderService;

        private readonly AbilitiesConfigsContainer _abilitiesConfigsContainer;

        private ReactiveEvent<Vector3> _setMineRequest;

        private ReactiveVariable<bool> _abilityActive;

        private IInputService _inputService;

        private CurrencyTypes _currencyTypes;

        private int _price;

        private Entity _currentEntityAbility;

        public AbilityIdleState(
            MainHeroHolderService mainHeroHolderService,
            IInputService inputService,
            WalletService walletService,
            AbilitiesConfigsContainer abilitiesConfigsContainer)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _inputService = inputService;
            _walletService = walletService;
            _abilitiesConfigsContainer = abilitiesConfigsContainer;
        }

        public override void Enter()
        {
            base.Enter();

            _mainHeroHolderService.CurrentAbilityActive += OnCurrentAbilityChange;
        }

        public override void Exit()
        {
            base.Exit();

            _mainHeroHolderService.CurrentAbilityActive -= OnCurrentAbilityChange;
        }

        public void Update(float deltaTime)
        {
            if(_currentEntityAbility == null)
                return;

            if (_abilityActive.Value == false)
                return;

            if (_inputService.Direction != Vector3.zero)
            {
                if (_walletService.Enought(_currencyTypes, _price) == false)
                    return;

                _setMineRequest.Invoke(_inputService.Direction);

                _walletService.Spend(_currencyTypes, _price);
            }
        }

        private void OnCurrentAbilityChange(AbilityTypes abilityTipes, Entity entity)
        {
            _currentEntityAbility = null;

            if(entity.TryGetSetMineRequest(out ReactiveEvent<Vector3> setMineRequest) 
                && entity.TryGetAbilityActive(out ReactiveVariable<bool> abilityActive))
            {
                _currentEntityAbility = entity;
                _setMineRequest = setMineRequest;
                _abilityActive = abilityActive;

                AbilityConfig abilityConfig =  _abilitiesConfigsContainer.GetConfigBy(abilityTipes);

                _currencyTypes = abilityConfig.Currency;
                _price = abilityConfig.Amount;
            }
        }
    }
}
