using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action ResetStatisticButtonClicked;

        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public TextTextListView StatisticsView { get; private set; }

        [SerializeField] private Button _resetStatisticButton;

        private void OnEnable()
        {
            _resetStatisticButton.onClick.AddListener(OnResetStatisticButtonClicked);
        }

        private void OnDisable()
        {
            _resetStatisticButton.onClick.RemoveListener(OnResetStatisticButtonClicked);
        }

        private void OnResetStatisticButtonClicked()
        {
            ResetStatisticButtonClicked?.Invoke();
        }
    }
}
