using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupHelper : MonoBehaviour
    {
        [SerializeField] private CharacterPopup _characterPopup;
        [SerializeField] private PopupInfo _popupInfo;
        private PopupModel _popupModel;
        private PopupPresenterFactory _popupPresenterFactory;

        [Inject]
        private void Construct(PopupPresenterFactory popupPresenterFactory)
        {
            _popupPresenterFactory = popupPresenterFactory;
            _popupModel = new PopupModel(_popupInfo);
        }

        public void ShowPopup()
        {
            var popupPresenter = _popupPresenterFactory.Create(_popupModel.UserInfo, _popupModel.PlayerLevel, _popupModel.CharacterInfo);
            _characterPopup.Show(popupPresenter);
        }
    }
}