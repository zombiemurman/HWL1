using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class ProcessTimerBombSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveEvent _startTimeBombEvent;

        private ReactiveVariable<float> _currentTimeBomb;

        private ReactiveVariable<bool> _inBombTimeProcess;

        private IDisposable _startTimeBombEventDisposable;

        public void OnInit(Entity entity)
        {
            _startTimeBombEvent = entity.StartTimeBombEvent;

            _currentTimeBomb = entity.CurrentTimeBomb;
            _inBombTimeProcess = entity.InBombTimeProcess;

            _startTimeBombEventDisposable = _startTimeBombEvent.Subscribe(OnStarTimeBombProcess);
        }

        public void OnUpdate(float deltaTime)
        {
            if(_inBombTimeProcess.Value == false)
                return;

            _currentTimeBomb.Value += deltaTime;
        }

        public void OnDispose()
        {
            _startTimeBombEventDisposable.Dispose();
        }

        private void OnStarTimeBombProcess()
        {
            _inBombTimeProcess.Value = true;
            _currentTimeBomb.Value = 0;
        }
    }
}
