using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class CurrentHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CurrentEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsDead : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class MustDie : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class MustSelfReleased : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class EnergyRecoveryInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyRecoveryCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyRecoveryValue : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class DisableCollidersOnDeath : IEntityComponent
    {
        public List<Collider> Value;
    }
}
