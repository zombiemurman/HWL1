using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class BombStartAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackRequest;

        private ReactiveVariable<float> _currentTimeBomb;
        private ReactiveVariable<float> _initialTimeBomb;

        private ReactiveVariable<bool> _inBombTimeProcess;

        IDisposable _currentTimeBombOnChangeDisposable;

        public void OnInit(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _currentTimeBomb = entity.CurrentTimeBomb;
            _initialTimeBomb = entity.InitialTimeBomb;
            _inBombTimeProcess = entity.InBombTimeProcess;

            _currentTimeBombOnChangeDisposable = _currentTimeBomb.Subscribe(OnCurrentTimeChange);
        }

        public void OnDispose()
        {
            _currentTimeBombOnChangeDisposable.Dispose();
        }
        private void OnCurrentTimeChange(float arg1, float currentTime)
        {
            if(currentTime >= _initialTimeBomb.Value)
            {
                _inBombTimeProcess.Value = false;
                _startAttackRequest.Invoke();
            }
        }
    }
}
