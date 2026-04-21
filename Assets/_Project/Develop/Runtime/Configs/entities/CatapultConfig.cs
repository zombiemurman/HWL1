using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewCatapultConfig", fileName = "CatapultConfig")]
    public class CatapultConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/CatapultEntity";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float MovingToDistance { get; private set; } = 100;
        [field: SerializeField] public ShootAbilityConfig ShootAbilityConfig { get; private set; }
        
    }
}
