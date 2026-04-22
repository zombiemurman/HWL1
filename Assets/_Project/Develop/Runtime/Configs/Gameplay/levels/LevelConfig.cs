using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _priceBomb;

        [SerializeField] private int _winAmountGold;
        
        [SerializeField] private int _winAmountDiamod;

        [SerializeField] private HeroConfig _heroConfig;

        [SerializeField] private List<StageConfig> _stageConfigs;

        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;

        public HeroConfig HeroConfig => _heroConfig;

        public int PriceBomb => _priceBomb;

        public int WinAmountGold => _winAmountGold;

        public int WinAmountDiamond => _winAmountDiamod;
    }
}
