using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures
{
    public class MainHeroApplyDamageView : EntityView
    {
        [SerializeField] private ParticleSystem _damagePrefab;

        [SerializeField] private Transform damagePosition;

        private ReactiveEvent<float> _damageRequest;

        private IDisposable _damageDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;

            _damageDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _damageDisposable.Dispose();
        }

        private void OnDamageRequest(float obj)
        {
            Instantiate(_damagePrefab, damagePosition.position, Quaternion.identity);
        }
    }
}
