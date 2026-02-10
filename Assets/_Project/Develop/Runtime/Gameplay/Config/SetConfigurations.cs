using Assets._Project.Develop.Runtime.Gameplay.Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Config
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/SetConfigurations", fileName = "SetConfigurations")]
    public class SetConfigurations : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public LevelConfig GetConfig(TypeGame typeGame) => _levelConfigs.First(config => config.TypeGame == typeGame);
    }
}
