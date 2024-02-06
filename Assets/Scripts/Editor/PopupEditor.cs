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

            }
        }

}