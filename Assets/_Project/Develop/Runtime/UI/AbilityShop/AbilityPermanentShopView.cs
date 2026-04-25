using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.AbilityShop
{
    public class AbilityPermanentShopView : PopupViewBase
    {
        [field: SerializeField] public IconTextListView CurrencyListView { get; private set; }

        [field: SerializeField] public AbilityPermanentListView AbilityPermanentListView { get; private set; }
    }
}
