namespace Lessons.Architecture.PM
{
    public sealed class PopupModel
    {
        public UserInfo UserInfo { get; private set; }
        public PlayerLevel PlayerLevel { get; private set; }
        public CharacterInfo CharacterInfo { get; private set; }

        public PopupModel(PopupInfo popupInfo)
        {
            CreateModels(popupInfo);
        }

        private void CreateModels(PopupInfo popupInfo)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.ChangeDescription(popupInfo.Description);
            userInfo.ChangeIcon(popupInfo.Icon);
            userInfo.ChangeName(popupInfo.Nick);
            UserInfo = userInfo;

            CharacterInfo characterInfo = new CharacterInfo();
            CharacterInfo = characterInfo;

            int[] values = popupInfo.StatValues;

            for (int i = 0; i < values.Length; i++)
            {
                CharacterStat characterStat = new CharacterStat();
                characterStat.ChangeValue(values[i]);
                characterStat.Name = popupInfo.StatNames[i];
                
                characterInfo.AddStat(characterStat);
            }

            PlayerLevel playerLevel = new PlayerLevel();
            PlayerLevel = playerLevel;
        }
    }
}