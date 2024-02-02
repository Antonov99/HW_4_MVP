using System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterPopup : MonoBehaviour
    {
        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Image _icon;

        [FormerlySerializedAs("_buyButton")] [SerializeField]
        private LevelUpButton levelUpButton;
        
        [SerializeField] private Button _closeButton;
        private IPopupPresenter _popupPresenter;
        private CompositeDisposable _disposable = new ();

        public void Show(IPresenter args)
        {
            if (args is not IPopupPresenter productPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }
            _disposable = new CompositeDisposable();
            gameObject.SetActive(true);
            _popupPresenter = productPresenter;
            _title.text = _popupPresenter.Nick;
            _description.text = _popupPresenter.Description;
            _icon.sprite = _popupPresenter.Icon;
            
            levelUpButton.SetPrice(_popupPresenter.Exp);
            
            _closeButton.onClick.AddListener(Hide);
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            var buttonState = _popupPresenter.CanLevelUp.Value
                ? UpgradeButtonState.Available
                : UpgradeButtonState.Locked;
            levelUpButton.SetState(buttonState);
        }

        private void Hide()
        {
            gameObject.SetActive(false); 
            _closeButton.onClick.RemoveListener(Hide);
            _disposable.Dispose();
        }
    }
}