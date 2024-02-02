using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class LevelUpButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [Space]
        [SerializeField] private Image _buttonBackground;

        [SerializeField] private Sprite _availableButtonSprite;

        [SerializeField] private Sprite _lockedButtonSprite;

        [Space]
        [SerializeField] private Text _priceText;

        [Space]
        [SerializeField]
        private UpgradeButtonState _state;

        private Image _priceIcon;

        public Button Button => _button;

        public void AddListener(UnityAction action)
        {
            Button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }

        public void SetPrice(string price)
        {
            _priceText.text = price;
        }

        public void SetIcon(Sprite icon)
        {
            _priceIcon.sprite = icon;
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? UpgradeButtonState.Available : UpgradeButtonState.Locked;
            SetState(state);
        }

        public void SetState(UpgradeButtonState state)
        {
            _state = state;

            switch (state)
            {
                case UpgradeButtonState.Available:
                    Button.interactable = true;
                    _buttonBackground.sprite = _availableButtonSprite;
                    break;
                case UpgradeButtonState.Locked:
                    Button.interactable = false;
                    _buttonBackground.sprite = _lockedButtonSprite;
                    break;
                default:
                    throw new Exception($"Undefined button state {state}!");
            }
        }
    }
}