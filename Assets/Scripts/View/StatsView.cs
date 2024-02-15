using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public class StatsView:MonoBehaviour
    {
        [SerializeField] private Text[] _statTexts;
        [SerializeField] private Text[] _statValues;
    
        private IStatsPresenter _statsPresenter;
        
        public void Show(IPresenter args)
        {
            if (args is not IStatsPresenter statsPresenter)
            {
                throw new Exception("Expected IProductPresenter");
            }

            _statsPresenter = statsPresenter;
            UpdateStats(_statsPresenter.StatNames,_statsPresenter.StatValues);
        }

        private void UpdateStats(string[] names, int[] values)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] is not null)
                {
                    _statTexts[i].text = names[i];
                    _statValues[i].text = values[i].ToString();
                }
            }
            for (int j=names.Length;j<6;j++)
            {
                _statTexts[j].text = "";
                _statValues[j].text = "";
            }
        }
    }
}