using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.BombFeatures
{
    public class InitialTimeBomb : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CurrentTimeBomb : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class StartTimeBombEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InBombTimeProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class EndAttackBombEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
}
