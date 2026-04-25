using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/AbilitiesPermanent/IncreaseExplosionDamageConfig", fileName = "IncreaseExplosionDamageConfig")]
    public class IncreaseExplosionDamageConfig : AbilityPermanentConfig
    {
        [field: SerializeField] public float IncreaseDamagePercent { get; private set; }
    }
}
