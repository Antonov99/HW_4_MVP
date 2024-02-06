using UnityEngine;

namespace Lessons.Architecture.PM
{
    [CreateAssetMenu(fileName = "Popup", menuName = "new Popup")]
    public sealed class PopupInfo : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _nick; 
        [SerializeField] [TextArea(3, 5)] private string _description;
        [Space]
        [SerializeField] private int _level; 
        [SerializeField] private int _exp;
        [SerializeField] private string[] _statNames;
        [SerializeField] private int[] _statValues;

        public Sprite Icon => _icon; 
        public string Nick => _nick; 
        public string Description => _description;   
        public int Level => _level;   
        public int Exp => _exp;
        public string[] StatNames => _statNames;
        public int[] StatValues => _statValues;
    }
}