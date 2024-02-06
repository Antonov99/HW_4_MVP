using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IPopupPresenter : IPresenter
    {
        string Nick { get; }
        string Description { get; }
        Sprite Icon { get; }      
        int Level { get; }
        int Exp { get; }
        int ExpRequired { get; }
        string[] StatNames { get; }
        int[] StatValues { get; }
    }
}