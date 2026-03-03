using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class StartTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startTeleportRequest;
        private ReactiveEvent _startTeleportEvent;

        private ICompositCondition _canStartTeleport;

        private IDisposable _teleportRequestDispouse;

        public void OnInit(Entity entity)
        {
            _startTeleportRequest = entity.StartTeleportRequest;
            _startTeleportEvent = entity.StartTeleportEvent;
            _canStartTeleport = entity.CanTeleport;

            _teleportRequestDispouse = _startTeleportRequest.Subscribe(OnStartTeleport);
        }

        public void OnDispose()
        {
            _teleportRequestDispouse.Dispose();
        }

        private void OnStartTeleport()
        {
            if (_canStartTeleport.Evaluate())
            {
                _startTeleportEvent.Invoke();

                Debug.Log("Start Teleport");
            }
            else
            {
                Debug.Log("Cant teleport");
            }
        }
    }
}
