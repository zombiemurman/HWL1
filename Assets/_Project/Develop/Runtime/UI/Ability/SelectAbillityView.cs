using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Ability
{
    public class SelectAbillityView : MonoBehaviour, IView
    {
        public event Action Click;

        [SerializeField] private Image _abilityIcon;

        [SerializeField] private TMP_Text _descriptionText;

        [SerializeField] private Image _currencyIcon;

        [SerializeField] private TMP_Text _currencyAmountText;

        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void SetDescription(string description) => _descriptionText.text = description;
        public void SetPrice(int price) => _currencyAmountText.text = price.ToString();
        public void SetAbilityIcon(Sprite icon) => _abilityIcon.sprite = icon;
        public void SetCurrencyIcon(Sprite icon) => _currencyIcon.sprite = icon;

        private void OnClicked()
        {
            Click?.Invoke();
        }
    }
}
