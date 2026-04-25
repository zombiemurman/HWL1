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

        public event Action AbilityShopButtonClicked;

        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public TextTextListView StatisticsView { get; private set; }

        [SerializeField] private Button _resetStatisticButton;
        
        [SerializeField] private Button _startGameButton;

        [SerializeField] private Button _abilityShopButton;

        private void OnEnable()
        {
            _resetStatisticButton.onClick.AddListener(OnResetStatisticButtonClicked);

            _startGameButton.onClick.AddListener(OnStartGameButtonClicked);

            _abilityShopButton.onClick.AddListener(OnAbilityShopCliked);
        }

        private void OnDisable()
        {
            _resetStatisticButton.onClick.RemoveListener(OnResetStatisticButtonClicked);

            _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);

            _abilityShopButton.onClick.RemoveListener(OnAbilityShopCliked);
        }

        private void OnStartGameButtonClicked()
        {
            StartGameButtonClicked?.Invoke();
        }

        private void OnResetStatisticButtonClicked()
        {
            ResetStatisticButtonClicked?.Invoke();
        }

        private void OnAbilityShopCliked()
        {
            AbilityShopButtonClicked?.Invoke();
        }
    }
}
