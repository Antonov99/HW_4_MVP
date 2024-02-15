using System;
using UnityEngine;
using UnityEngine.UI;


namespace Lessons.Architecture.PM
{
    public class UserView:MonoBehaviour
    {
        [SerializeField] private Text _title;

        [SerializeField] private Text _description;

        [SerializeField] private Image _icon;

        [SerializeField] private Text _level;
        
        [SerializeField] private Text _exp;
        
        [SerializeField] private Button _levelUpButton;
        
        [SerializeField] private Sprite _disabledButton;
        [SerializeField] private Sprite _enabledButton;

        private IUserPresenter _userPresenter;

        public void Show(IPresenter args)
        {
            if (args is not IUserPresenter userPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }

            _userPresenter = userPresenter;
            UpdateName(_userPresenter.Nick);

            UpdateDescription(_userPresenter.Description);

            UpdateIcon(_userPresenter.Icon);
            
            UpdateLevel(_userPresenter.Level);
            
            UpdateExperience(_userPresenter.ExpText);
            
            _userPresenter.OnNameChanged += UpdateName;
            _userPresenter.OnDescriptionChanged += UpdateDescription;
            _userPresenter.OnIconChanged += UpdateIcon;
            _userPresenter.OnLevelUp += UpdateLevel;
            _userPresenter.OnExperienceChanged += UpdateExperience;
            
            UpdateButtonState();
            _levelUpButton.onClick.AddListener(LevelUp); 
        }

        private void UpdateName(string userName) => _title.text = userName;
        private void UpdateDescription(string description) => _description.text = description;
        private void UpdateIcon(Sprite icon) => _icon.sprite = icon;

        private void UpdateLevel(string level)
        {
            _level.text = level;
            UpdateButtonState();
        }

        private void LevelUp()
        {
            _userPresenter.LevelUp();
        }

        private void UpdateExperience(string expText)
        {
            _exp.text = expText;
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            if (_userPresenter.CanLevelUp())
            {
                _levelUpButton.image.sprite = _enabledButton;
            }
            else
            {
                _levelUpButton.image.sprite = _disabledButton;
            }
        }

        void OnDisable()
        {
            _levelUpButton.onClick.RemoveListener(UpdateButtonState);
        }
    }
}