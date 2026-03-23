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
        
        public event Action StartGameButtonClicked;

        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public TextTextListView StatisticsView { get; private set; }

        [SerializeField] private Button _resetStatisticButton;
        
        [SerializeField] private Button _startGameButton;

        private void OnEnable()
        {
            _resetStatisticButton.onClick.AddListener(OnResetStatisticButtonClicked);

            _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        }

        private void OnDisable()
        {
            _resetStatisticButton.onClick.RemoveListener(OnResetStatisticButtonClicked);

            _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        }

        private void OnStartGameButtonClicked()
        {
            StartGameButtonClicked?.Invoke();
        }

        private void OnResetStatisticButtonClicked()
        {
            ResetStatisticButtonClicked?.Invoke();
        }
    }
}
