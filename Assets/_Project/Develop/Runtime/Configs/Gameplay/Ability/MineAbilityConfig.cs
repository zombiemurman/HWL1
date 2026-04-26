using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/MineAbilityConfig", fileName = "MineAbilityConfig")]
    public class MineAbilityConfig : AbilityBaseConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Bomb";
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public float Time { get; private set; }
    }
}
