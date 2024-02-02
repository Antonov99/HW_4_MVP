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
            
                var lessonHelper = (PopupHelper) target;
            
                if (GUILayout.Button("ShowPopup"))
                {
                    lessonHelper.ShowPopup();
                }

            }
        }

}