using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures
{
    public class IsMainHero : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}
