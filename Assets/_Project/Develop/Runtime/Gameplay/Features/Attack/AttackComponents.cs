using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class RadiusAttack : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class DamageAttack : IEntityComponent
    {
        public ReactiveVariable<float> Value; 
    }

    public class inAttackProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class TakeDamageRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }
}
