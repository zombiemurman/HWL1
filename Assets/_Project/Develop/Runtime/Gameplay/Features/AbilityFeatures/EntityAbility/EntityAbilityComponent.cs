using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.EntityAbility
{
    public class AbilityStorage : IEntityComponent
    {
        public Dictionary<AbilityTipes, Entity> Value;
    }

    public class AbilityActive : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}
