using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportProcessSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startTeleportEvent;
        private ReactiveEvent _endTeleportEvent;

        private ReactiveVariable<float> _radiusTeleport;

        private Transform _entityTransform;

        IDisposable _startTeleportDuispouse;

        public void OnInit(Entity entity)
        {
            _startTeleportEvent = entity.StartTeleportEvent;
            _endTeleportEvent = entity.EndTeleportEvent;
            _radiusTeleport = entity.RadiusTeleport;
            _entityTransform = entity.EntityTransform;

            _startTeleportDuispouse = _startTeleportEvent.Subscribe(OnStartTeleport);
        }

        public void OnDispose()
        {
            _startTeleportDuispouse.Dispose();
        }

        private void OnStartTeleport()
        {
            TeleportRandomPosition();

            _endTeleportEvent.Invoke();
        }

        private void TeleportRandomPosition()
        {
            Vector2 randomCircle = Random.insideUnitCircle.normalized * _radiusTeleport.Value;

            Vector3 newPos = _entityTransform.position + new Vector3(randomCircle.x, 0, randomCircle.y);

            _entityTransform.position = newPos;
        }
    }
}
