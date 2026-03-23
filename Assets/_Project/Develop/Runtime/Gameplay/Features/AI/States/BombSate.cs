using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class BombSate : State, IUpdatableState
    {
        private readonly EntitiesFactory _entitiesFactory;

        private readonly WalletService _walletService;

        private int _price;

        public BombSate(
            EntitiesFactory entitiesFactory,
            WalletService walletService,
            int price)
        {
            _entitiesFactory = entitiesFactory;
            _walletService = walletService;
            _price = price;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if(_walletService.Enought(CurrencyTypes.Gold, _price) == false)
                    return;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, Layers.GroundMask))
                {
                    _entitiesFactory.CreateBomb(hit.point);

                    _walletService.Spend(CurrencyTypes.Gold, _price);
                }
            }
        }
    }
}
