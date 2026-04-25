using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/AbilitiesPermanent/AbilityPermanentConfigsContainer", fileName = "AbilityPermanentConfigsContainer")]
    public class AbilityPermanentConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<AbilityPermanentConfig> _abilityConfigs;

        public IReadOnlyList<AbilityPermanentConfig> AbilityConfigs => _abilityConfigs;

        public AbilityPermanentConfig GetConfigBy(string ID) => _abilityConfigs.First(config => config.ID == ID);
    }
}
