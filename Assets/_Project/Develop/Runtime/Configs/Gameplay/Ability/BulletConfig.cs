using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/BulletConfig", fileName = "BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}
