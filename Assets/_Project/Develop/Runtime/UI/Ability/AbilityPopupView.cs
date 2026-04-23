using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Ability
{
    public class AbilityPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _idleTime;

        [SerializeField] private AbilityListView _abilityListView;

        public AbilityListView AbilityListView => _abilityListView;

        public void SetTime(string time) => _idleTime.text = time;
    }
}
