using UnityEngine;
using UniRx;

namespace Lessons.Architecture.PM
{
    public interface IPopupPresenter : IPresenter
    {
        string Nick { get; }
        string Description { get; }
        Sprite Icon { get; }      
        string Level { get; }
        string Exp { get; }
        IReadOnlyReactiveProperty<bool> CanLevelUp { get; }
    }
}