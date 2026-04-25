using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using UnityEditor.Playables;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class AbilityPermanentOnAddActivatorSystem : IInitializableSystem, IDisposableSystem
    {
        private AbilityPermanentList _abilitiesList;

        public void OnInit(Entity entity)
        {
            _abilitiesList = entity.AbilitiesPermanents;

            _abilitiesList.Added += OnAbilityAdded;

            foreach (AbilityPermanent ability in _abilitiesList.Elements)
                ability.Activate();
        }

        private void OnAbilityAdded(AbilityPermanent ability)
        {
            ability.Activate();
        }

        public void OnDispose()
        {
            _abilitiesList.Added -= OnAbilityAdded;
        }
    }
}
