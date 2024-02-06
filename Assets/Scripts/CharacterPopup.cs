using System;
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

        [SerializeField] private Button _closeButton;
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
            
            UpdateLevel(_popupPresenter.Level);
            
            UpdateExperience(_popupPresenter.Exp,_popupPresenter.ExpRequired);

            UpdateStats(_popupPresenter.StatNames,_popupPresenter.StatValues);
            
            UpdateButtonState();
            
            _closeButton.onClick.AddListener(Hide);
        }

        public void UpdateName(string userName) => _title.text = userName;
        public void UpdateDescription(string description) => _description.text = description;
        public void UpdateIcon(Sprite icon) => _icon.sprite = icon;
        public void UpdateLevel(int level) => _level.text = "Level: " + level;
        public void UpdateExperience(int exp,int expRequired)=>_exp.text = "Exp: " + exp + "/"+expRequired;

        private void UpdateButtonState()
        {
            
        }
        
        private void UpdateStats(string[] names, int[] values)
        {
            for (int i = 0; i < names.Length; i++)
            {
                _statTexts[i].text = names[i];
                _statValues[i].text = values[i].ToString();
            }
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}