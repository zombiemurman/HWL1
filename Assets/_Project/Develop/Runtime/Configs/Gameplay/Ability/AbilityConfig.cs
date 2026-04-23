using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/NewAbilityConfig", fileName = "AbilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public AbilityTypes Ability { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public CurrencyTypes Currency { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }

    }
}
