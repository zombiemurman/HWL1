using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewShootAbilityConfig", fileName = "ShootAbilityConfig")]
    public class ShootAbilityConfig : EntityConfig
    {
        [field: SerializeField, Min(0)] public float AttackProcessTime { get; private set; } = 1f;
        [field: SerializeField, Min(0)] public float Cooldown { get; private set; } = 2f;
        [field: SerializeField, Min(0)] public float Delay { get; private set; } = 0.3f;
        [field: SerializeField] public BulletConfig BulletConfig { get; private set; }
    }
}
