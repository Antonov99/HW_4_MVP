using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IUserPresenter:IPresenter
    {
        string Nick { get; }
        string Description { get; }
        Sprite Icon { get; }      
        string Level { get; }
        int Exp { get; }
        int ExpRequired { get; }
        public string ExpText { get; }
        
        public event Action<string> OnNameChanged; 
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged; 
        public event Action<string> OnLevelUp;
        public event Action<string> OnExperienceChanged;
        public void LevelUp();
        public bool CanLevelUp();
    }
}