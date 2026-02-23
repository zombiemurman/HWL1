using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Config
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/NewCharacterControllerMovementConfig", fileName = "CharacterControllerMovementConfig")]
    public class CharacterControllerMovementConfig : ScriptableObject
    {
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}
