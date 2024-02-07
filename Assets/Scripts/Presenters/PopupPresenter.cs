using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PopupPresenter : IPopupPresenter
    {
        public string Nick { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public int Level { get; }
        public int Exp { get; }
        public int ExpRequired { get; }
        public string[] StatNames { get; }
        public int[] StatValues { get; }

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;
        public event Action<string> OnLevelUp;
        public event Action<string> OnExperienceChanged;

        private readonly PlayerLevel _playerLevel;

        public PopupPresenter(UserInfo userInfo, PlayerLevel playerLevel, CharacterInfo characterInfo)
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
            Level = playerLevel.CurrentLevel;
            Exp = playerLevel.CurrentExperience;
            ExpRequired = playerLevel.RequiredExperience;

            var massStats = characterInfo.GetStats();
            StatNames = new string[massStats.Length];
            StatValues = new int[massStats.Length];
            for (int i = 0; i < massStats.Length; i++)
            {
                StatNames[i] = massStats[i].Name;
                StatValues[i] = massStats[i].Value;
            }
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
