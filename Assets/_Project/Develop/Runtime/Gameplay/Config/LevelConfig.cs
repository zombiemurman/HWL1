using Assets._Project.Develop.Runtime.Gameplay.Game;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Config
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public TypeGame TypeGame { get; private set; }
        [field: SerializeField] public string[] Symbols { get; private set; }
        [field: SerializeField] public int EquallyWin { get; private set; }
        [field: SerializeField] public int NoEquallyDefeat { get; private set; }
    }
}
