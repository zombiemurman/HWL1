using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class StartAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackRequest;
        private ReactiveEvent _startAttackEvent;

        private ReactiveVariable<bool> _inAttackProcess;

        private ICompositCondition _canStartAttack;

        private IDisposable _attackRequestDispouse;

        public void OnInit(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _startAttackEvent = entity.StartAttackEvent;

            _inAttackProcess = entity.inAttackProcess;

            _canStartAttack = entity.CanStartAttack;

            _attackRequestDispouse = _startAttackRequest.Subscribe(OnAttackRequest);
        }

        public void OnDispose()
        {
            _attackRequestDispouse.Dispose();   
        }

        private void OnAttackRequest()
        {
            if(_canStartAttack.Evaluate())
            {
                _inAttackProcess.Value = true;
                
                _startAttackEvent.Invoke();

                Debug.Log("Start Attack");
            }
            else
            {
                Debug.Log("Cant attack");
            }
        }
    }
}
