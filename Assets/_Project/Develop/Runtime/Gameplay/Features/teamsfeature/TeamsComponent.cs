using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Components
{
    public class Team : IEntityComponent
    {
        public ReactiveVariable<Teams> Value;
    }

    public class IsTouchAnotherTeam : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}
