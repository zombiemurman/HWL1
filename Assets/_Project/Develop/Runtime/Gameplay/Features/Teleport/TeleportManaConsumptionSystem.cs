using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportManaConsumptionSystem : IInitializableSystem, IDisposable
    {
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _energyTeleportValue;

        private ReactiveEvent _startTeleportEvent;
        private ReactiveEvent _teleportManaConsumptionEvent;

        IDisposable _startTeleportEventDispouse;
        IDisposable _startTeleportManaConsumptionEvent;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentEnergy;
            _energyTeleportValue = entity.EnergyTeleportValue;
            _startTeleportEvent = entity.StartTeleportEvent;
            _teleportManaConsumptionEvent = entity.TeleportManaConsumptionEvent;

            _startTeleportEventDispouse = _startTeleportEvent.Subscribe(OnEnegyConsumption);
            _startTeleportManaConsumptionEvent = _teleportManaConsumptionEvent.Subscribe(OnEnegyConsumption);
        }

        public void Dispose()
        {
            _startTeleportEventDispouse.Dispose();
            _startTeleportManaConsumptionEvent.Dispose();
        }

        private void OnEnegyConsumption()
        {
            _currentEnergy.Value -= _energyTeleportValue.Value;
        }
    }
}
