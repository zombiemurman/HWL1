using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest;

        private ReactiveVariable<float> _health;

        private IDisposable _damageDisposable;

        public void OnInit(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;
            _health = entity.CurrentHealth;

            _damageDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }

        public void OnDispose()
        {
            _damageDisposable.Dispose();
        }

        private void OnDamageRequest(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health.Value = MathF.Max(_health.Value - damage, 0);

            Debug.Log($"Damage - {damage}");
        }
    }
}
