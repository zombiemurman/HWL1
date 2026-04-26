using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/PuddleAbilityConfig", fileName = "PuddleAbilityConfig")]
    public class PuddleAbilityConfig : AbilityBaseConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/PuddleEntity";
        [field: SerializeField] public float Damage { get; private set; }
    }
}
