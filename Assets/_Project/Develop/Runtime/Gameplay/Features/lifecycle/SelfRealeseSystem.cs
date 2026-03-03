using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class SelfRealeseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _lifeContext;

        private Entity _entity;

        private ICompositCondition _mustSelfReleased;

        public SelfRealeseSystem(EntitiesLifeContext lifeContext)
        {
            _lifeContext = lifeContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _mustSelfReleased = entity.MustSelfReleased;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_mustSelfReleased.Evaluate())
                _lifeContext.Release(_entity);
        }
    }
}
