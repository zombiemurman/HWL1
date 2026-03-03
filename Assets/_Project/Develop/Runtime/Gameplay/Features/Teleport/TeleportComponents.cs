using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class StartTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class StartTeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class EndTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanTeleport : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class EnergyTeleportValue : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EntityTransform : IEntityComponent
    {
        public Transform Value;
    }

    public class RadiusTeleport : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}
