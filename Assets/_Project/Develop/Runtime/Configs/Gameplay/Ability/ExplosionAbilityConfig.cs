using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/ExplosionAbilityConfig", fileName = "ExplosionAbilityConfig")]
    public class ExplosionAbilityConfig : AbilityBaseConfig
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}
