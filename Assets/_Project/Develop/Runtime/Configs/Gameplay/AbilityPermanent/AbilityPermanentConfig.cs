using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent
{
    public abstract class AbilityPermanentConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] public CurrencyTypes Currency { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}
