﻿using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupHelper : MonoBehaviour
    {
        [SerializeField] private CharacterPopup _characterPopup;
        [SerializeField] private PopupInfo _popupInfo;
        
        private PopupModel _popupModel;
        private PopupPresenterFactory _popupPresenterFactory;
        
        [SerializeField] private string newName;
        [SerializeField] private string newDescription;
        [SerializeField] private Sprite newIcon;
        [SerializeField] private int expToAdd;
        
        [SerializeField] private string nameToAdd;
        [SerializeField] private int valueToAdd;
        [SerializeField] private string nameToRemove;
        
        [SerializeField] private string nameToChange;
        [SerializeField] private int valueToChange;
        
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

        public void AddExp()
        {
            _popupModel.PlayerLevel.AddExperience(expToAdd);
        }

        public void Rename()
        {
            _popupModel.UserInfo.ChangeName(newName);
        }

        public void ChangeDescription()
        {
            _popupModel.UserInfo.ChangeDescription(newDescription);
        }
        
        public void ChangeIcon()
        {
            _popupModel.UserInfo.ChangeIcon(newIcon);
        }

        public void RemoveStat()
        {
            var stat=_popupModel.CharacterInfo.GetStat(nameToRemove);
            _popupModel.CharacterInfo.RemoveStat(stat);
            
            ShowPopup();
        }

        public void AddStat()
        {
            if (_popupModel.CharacterInfo.GetStats().Length >= 6) return;
            
            CharacterStat characterStat = new CharacterStat();
            characterStat.Name = nameToAdd;
            characterStat.ChangeValue(valueToAdd);
            _popupModel.CharacterInfo.AddStat(characterStat);

            ShowPopup();
        }

        public void ChangeStatValue()
        {
            _popupModel.CharacterInfo.GetStat(nameToChange).ChangeValue(valueToChange);
            ShowPopup();
        }
    }
}