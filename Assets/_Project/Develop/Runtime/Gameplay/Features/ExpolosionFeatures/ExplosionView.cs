using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class ExplosionView : EntityView
    {
        [SerializeField] private ParticleSystem _explosionEffectPrefab;

        private ReactiveEvent _starAttack;

        private ReactiveVariable<Vector3> _position;

        private IDisposable _startAttackDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            Entity explosionAbility = entity.AbilityStorage[AbilityTypes.Explosion];

            _position = explosionAbility.ExplosionPoint;

            _starAttack = explosionAbility.StartAttackEvent;

            _startAttackDisposable = _starAttack.Subscribe(OnStartAttack);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _startAttackDisposable.Dispose();
        }

        private void OnStartAttack()
        {
            Vector3 position = new Vector3(_position.Value.x, 5, _position.Value.z);
            
            Instantiate(_explosionEffectPrefab, position, Quaternion.identity);
        }
    }
}
