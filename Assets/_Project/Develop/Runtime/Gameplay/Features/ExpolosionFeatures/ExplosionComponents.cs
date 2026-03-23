using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ExpolosionFeatures
{
    public class ExplosionPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class ExplosionRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ExplosionDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ExplosionCamera : IEntityComponent
    {
        public Camera Value;
    }
}
