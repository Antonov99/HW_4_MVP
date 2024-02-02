using UnityEngine;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PopupPresenter : IPopupPresenter
    {
        private readonly PopupInfo _popupInfo;
        public string Nick { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public string Level { get; }
        public string Exp { get; }
        public IReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        private readonly ReactiveProperty<bool> _canLevelUp = new();
        public PopupPresenter(PopupInfo popupInfo)
        {
            _popupInfo = popupInfo;
            Nick = _popupInfo.Nick;
            Description = _popupInfo.Description;
            Icon = _popupInfo.Icon;
            Level = _popupInfo.Level.ToString();
            Exp = _popupInfo.Exp.ToString();
        }
    }
}