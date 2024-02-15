using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class UserPresenter:IUserPresenter
    {
        public string Nick { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public string Level { get; }
        public int Exp { get; }
        public int ExpRequired { get; }
        public string ExpText { get; }
        
        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;
        public event Action<string> OnLevelUp;
        public event Action<string> OnExperienceChanged;

        private readonly PlayerLevel _playerLevel;

        public UserPresenter(UserInfo userInfo, PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            userInfo.OnNameChanged += UpdateName;
            userInfo.OnDescriptionChanged += UpdateDescription;
            userInfo.OnIconChanged += UpdateIcon;
            playerLevel.OnLevelUp += UpdateLevel;
            playerLevel.OnExperienceChanged += UpdateExperience;
            
            Nick = userInfo.Name;
            Description = userInfo.Description;
            Icon = userInfo.Icon;
            Level = "Level: "+playerLevel.CurrentLevel;
            Exp = playerLevel.CurrentExperience;
            ExpRequired = playerLevel.RequiredExperience;
            ExpText = Exp + "/" + ExpRequired;
        }
        
        public void LevelUp()
        {
            _playerLevel.LevelUp();
            UpdateExperience(_playerLevel.CurrentExperience);
        }

        public bool CanLevelUp()
        {
            return _playerLevel.CanLevelUp();
        }

        private void UpdateName(string name)
        {
            OnNameChanged?.Invoke(name);
        }

        private void UpdateDescription(string description)
        {
            OnDescriptionChanged?.Invoke(description);
        }

        private void UpdateIcon(Sprite icon)
        {
            OnIconChanged?.Invoke(icon);
        }

        private void UpdateLevel(int level)
        {
            OnLevelUp?.Invoke("Level: "+level);
        }

        private void UpdateExperience(int exp)
        {
            string expText = exp + "/" + _playerLevel.RequiredExperience;
            OnExperienceChanged?.Invoke(expText);
        }
    }
}