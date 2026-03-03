using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _isDeath;

        private ICompositCondition _mustDie;

        public void OnInit(Entity entity)
        {
            _isDeath = entity.IsDead;
            _mustDie = entity.MustDie;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDeath.Value)
                return;

            if(_mustDie.Evaluate())
                _isDeath.Value = true;
        }
    }
}
