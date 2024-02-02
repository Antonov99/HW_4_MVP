using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupHelper : MonoBehaviour
    {
        [SerializeField] private CharacterPopup _characterPopup;
        [SerializeField] private PopupInfo _popupInfo;
        private PopupPresenterFactory _popupPresenterFactory;

        [Inject]
        private void Construct(PopupPresenterFactory popupPresenterFactory)
        {
            _popupPresenterFactory = popupPresenterFactory;
        }
        
        public void ShowPopup()
        {
            var popupPresenter = _popupPresenterFactory.Create(_popupInfo);
            _characterPopup.Show(popupPresenter);
        }
    }
}