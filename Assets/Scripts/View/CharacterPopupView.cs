using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterPopupView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        private IPopupPresenter _popupPresenter;

        public void Show(IPresenter args)
        {
            if (args is not IPopupPresenter popupPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }

            gameObject.SetActive(true);
            _popupPresenter = popupPresenter;
            
            _closeButton.onClick.AddListener(Hide);
        }

 
        private void Hide()
        {
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}