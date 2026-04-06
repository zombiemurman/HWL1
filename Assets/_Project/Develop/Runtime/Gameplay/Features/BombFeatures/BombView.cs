using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class BombView : EntityView
    {
        [SerializeField] private ParticleSystem _explosionEffectPrefab;

        private ReactiveEvent _starAttack;

        private Transform _position;

        private IDisposable _startAttackDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _position = entity.EntityTransform;

            _starAttack = entity.StartAttackEvent;

            _startAttackDisposable = _starAttack.Subscribe(OnStartAttack);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _startAttackDisposable.Dispose();
        }

        private void OnStartAttack()
        {
            Vector3 position = new Vector3(_position.position.x, 5, _position.position.z);

            Instantiate(_explosionEffectPrefab, position, Quaternion.identity);
        }
    }
}
