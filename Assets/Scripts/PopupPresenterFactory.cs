namespace Lessons.Architecture.PM
{
    public sealed class PopupPresenterFactory
    {
        public IPopupPresenter Create(PopupInfo popupInfo)
        {
            return new PopupPresenter(popupInfo);
        }
    }
}