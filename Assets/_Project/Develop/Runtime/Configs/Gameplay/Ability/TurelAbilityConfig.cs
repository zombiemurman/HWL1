using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/TurelAbilityConfig", fileName = "TurelAbilityConfig")]
    public class TurelAbilityConfig : AbilityBaseConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/TurelEntity";
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public float InitialTime { get; private set; }
        [field: SerializeField] public float DelayTime { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float SpeedBullet { get; private set; }
        [field: SerializeField] public BulletConfig BulletConfig { get; private set; }
    }
}
