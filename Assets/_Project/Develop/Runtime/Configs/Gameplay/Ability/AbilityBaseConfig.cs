using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Ability
{
    public abstract class AbilityBaseConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public bool MainAbility { get; private set; }
        [field: SerializeField] public AbilityTypes Ability { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public CurrencyTypes Currency { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}
