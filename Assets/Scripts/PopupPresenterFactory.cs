namespace Lessons.Architecture.PM
{
    public sealed class PopupPresenterFactory
    {
        public IPopupPresenter CreatePopupPresenter()
        {
            return new PopupPresenter();
        }

        public IUserPresenter CreateUserPresenter(UserInfo userInfo, PlayerLevel playerLevel)
        {
            return new UserPresenter(userInfo, playerLevel);
        }

        public IStatsPresenter CreateStatsPresenter(CharacterInfo characterInfo)
        {
            return new StatsPresenter(characterInfo);
        }
    }
}