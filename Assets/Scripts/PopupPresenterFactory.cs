namespace Lessons.Architecture.PM
{
    public sealed class PopupPresenterFactory
    {
        public IPopupPresenter Create(UserInfo userInfo, PlayerLevel playerLevel, CharacterInfo characterInfo)
        {
            return new PopupPresenter(userInfo,playerLevel,characterInfo);
        }
    }
}