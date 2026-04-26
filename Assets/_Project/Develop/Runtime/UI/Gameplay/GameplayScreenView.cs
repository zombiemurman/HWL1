using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.GameplayRandomSymbol;
using Assets._Project.Develop.Runtime.UI.HPBar;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextListView WalletView { get; private set; }

        [field: SerializeField] public Transform Gameplay {  get; private set; }

        [field: SerializeField] public EntitiesHealthDisplay EntitiesHealthDisplay { get; private set; }
        
        [field: SerializeField] public IconListView IconListView { get; private set; }

    }
}
