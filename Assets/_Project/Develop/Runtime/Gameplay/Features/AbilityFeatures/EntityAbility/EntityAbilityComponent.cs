using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility
{
    public class AbilityStorage : IEntityComponent
    {
        public Dictionary<AbilityTypes, Entity> Value;
    }

    public class AbilityActive : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class DebugText : IEntityComponent
    {
        public ReactiveVariable<string> Value;
    }
}
