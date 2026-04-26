using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/AbilitiesConfigsContainer", fileName = "AbilitiesConfigsContainer")]
    public class AbilitiesConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<AbilityBaseConfig> _abilityConfigs;

        public IReadOnlyList<AbilityBaseConfig> AbilityConfigs => _abilityConfigs;

        public AbilityBaseConfig GetConfigBy(string ID) => _abilityConfigs.First(config => config.ID == ID);
        public AbilityBaseConfig GetConfigBy(AbilityTypes types) => _abilityConfigs.First(config => config.Ability == types);
    }
}
