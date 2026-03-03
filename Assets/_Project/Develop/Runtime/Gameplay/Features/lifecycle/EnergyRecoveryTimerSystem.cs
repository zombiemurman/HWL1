using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.lifecycle
{
    public class EnergyRecoveryTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        public ReactiveVariable<float> _initialTime;
        public ReactiveVariable<float> _currentTime;
        public ReactiveVariable<float> _energy;

        public ReactiveVariable<float> _maxEnergy;
        public ReactiveVariable<float> _currentEnergy;

        public void OnInit(Entity entity)
        {
            _initialTime = entity.EnergyRecoveryInitialTime;
            _currentTime = entity.EnergyRecoveryCurrentTime;
            _energy = entity.EnergyRecoveryValue;

            _maxEnergy = entity.MaxEnergy;
            _currentEnergy = entity.CurrentEnergy;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_currentEnergy.Value == _maxEnergy.Value)
            {
                _currentTime.Value = 0;

                return;
            }

            _currentTime.Value += deltaTime;

            if(_currentTime.Value >= _initialTime.Value)
            {
                _currentTime.Value = 0;

                _currentEnergy.Value = MathF.Min(_currentEnergy.Value + _energy.Value, _maxEnergy.Value);

                Debug.Log($"Восстановлено энергии {_currentEnergy.Value}");
            }
        }
    }
}
