
using Assets._Project.Develop.Runtime.Configs.Gameplay.Ability;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewHeroConfig", fileName = "HeroConfig")]
    public class HeroConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/ExplosionEntity";
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float ExplosionRadius { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float ExplosionDamage { get; private set; } = 120;
        [field: SerializeField, Min(0)] public float AttackCooldownInitialTime { get; private set; } = 2f;

        [field: SerializeField] public AbilitiesConfigsContainer Ability { get; private set; }
    }
}
