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

        IDisposable _startTeleportEventDispouse;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentEnergy;
            _energyTeleportValue = entity.EnergyTeleportValue;
            _startTeleportEvent = entity.StartTeleportEvent;

            _startTeleportEventDispouse = _startTeleportEvent.Subscribe(OnStartTeleport);
        }

        public void Dispose()
        {
            _startTeleportEventDispouse.Dispose();
        }

        private void OnStartTeleport()
        {
            _currentEnergy.Value -= _energyTeleportValue.Value;
        }
    }
}
