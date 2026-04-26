using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/GameplaySettingsConfig", fileName = "GameplaySettingsConfig")]
    public class GameplaySettingsConfig : ScriptableObject
    {
        [field: SerializeField] public float TimeIdle { get; private set; }
    }
}
