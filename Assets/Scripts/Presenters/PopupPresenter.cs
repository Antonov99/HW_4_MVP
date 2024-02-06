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

        public PopupPresenter(UserInfo userInfo, PlayerLevel playerLevel, CharacterInfo characterInfo)
        {
            Nick = userInfo.Name;
            Description = userInfo.Description;
            Icon = userInfo.Icon;
            Level = playerLevel.CurrentLevel;
            Exp = playerLevel.CurrentExperience;
            ExpRequired = playerLevel.RequiredExperience;
            
            var massStats = characterInfo.GetStats();
            StatNames = new string[massStats.Length];
            StatValues= new int[massStats.Length];
            for (int i = 0; i < massStats.Length; i++)
            {
                StatNames[i] = massStats[i].Name;
                StatValues[i] = massStats[i].Value;
            }
        }
    }
}