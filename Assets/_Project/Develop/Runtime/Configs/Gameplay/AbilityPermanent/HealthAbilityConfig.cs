using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/AbilitiesPermanent/HealthAbilityConfig", fileName = "HealthAbilityConfig")]
    public class HealthAbilityConfig : AbilityPermanentConfig
    {
        [field: SerializeField] public float HealthPercent { get; private set; }
    }
}
