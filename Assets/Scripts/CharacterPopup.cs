using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private Text _title;

        [SerializeField] private Text _description;

        [SerializeField] private Image _icon;

        [SerializeField] private Text _level;
        
        [SerializeField] private Text _exp;

        [SerializeField] private Text[] _statTexts;
        [SerializeField] private Text[] _statValues;

        [SerializeField] private Button _levelUpButton;
        [SerializeField] private Button _closeButton;
        
        [SerializeField] private Sprite _disabledButton;
        [SerializeField] private Sprite _enabledButton;
        
        private IPopupPresenter _popupPresenter;

        public void Show(IPresenter args)
        {
            if (args is not IPopupPresenter popupPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }

            gameObject.SetActive(true);
            _popupPresenter = popupPresenter;

            UpdateName(_popupPresenter.Nick);

            UpdateDescription(_popupPresenter.Description);

            UpdateIcon(_popupPresenter.Icon);
            
            UpdateLevel("Level: "+_popupPresenter.Level);
            
            UpdateExperience(_popupPresenter.Exp+"/"+_popupPresenter.ExpRequired);

            UpdateStats(_popupPresenter.StatNames,_popupPresenter.StatValues);
            
            _popupPresenter.OnNameChanged += UpdateName;
            _popupPresenter.OnDescriptionChanged += UpdateDescription;
            _popupPresenter.OnIconChanged += UpdateIcon;
            _popupPresenter.OnLevelUp += UpdateLevel;
            _popupPresenter.OnExperienceChanged += UpdateExperience;
            
            UpdateButtonState();
            _levelUpButton.onClick.AddListener(_popupPresenter.LevelUp);
            _levelUpButton.onClick.AddListener(UpdateButtonState);
            _closeButton.onClick.AddListener(Hide);
        }
        
        public void UpdateName(string userName) => _title.text = userName;
        public void UpdateDescription(string description) => _description.text = description;
        public void UpdateIcon(Sprite icon) => _icon.sprite = icon;

        public void UpdateLevel(string level)
        {
            _level.text = level;
            UpdateButtonState();
        }

        public void UpdateExperience(string expText)
        {
            _exp.text = expText;
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            if (_popupPresenter.CanLevelUp())
            {
                _levelUpButton.image.sprite = _enabledButton;
                
            }
            else
            {
                _levelUpButton.image.sprite = _disabledButton;
            }
        }
        
        private void UpdateStats(string[] names, int[] values)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] is not null)
                {
                    _statTexts[i].text = names[i];
                    _statValues[i].text = values[i].ToString();
                }
            }
            for (int j=names.Length;j<6;j++)
            {
                _statTexts[j].text = "";
                _statValues[j].text = "";
            }
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}