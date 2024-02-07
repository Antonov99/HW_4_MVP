using UnityEditor;
using UnityEngine;


namespace Lessons.Architecture.PM.Editor
{
    
        [CustomEditor(typeof(PopupHelper))]
        public sealed class PopupEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
            
                var popupHelper = (PopupHelper) target;
            
                if (GUILayout.Button("ShowPopup"))
                {
                    popupHelper.ShowPopup();
                }
                
                if (GUILayout.Button("Add exp"))
                {
                    popupHelper.AddExp();
                }
                if (GUILayout.Button("Rename"))
                {
                    popupHelper.Rename();
                }
                if (GUILayout.Button("Change Description"))
                {
                    popupHelper.ChangeDescription();
                }
                if (GUILayout.Button("Change Icon"))
                {
                    popupHelper.ChangeIcon();
                }
                if (GUILayout.Button("RemoveStat"))
                {
                    popupHelper.RemoveStat();
                }
                if (GUILayout.Button("AddStat"))
                {
                    popupHelper.AddStat();
                }
                if (GUILayout.Button("ChangeStatValue"))
                {
                    popupHelper.ChangeStatValue();
                }
            }
        }

}