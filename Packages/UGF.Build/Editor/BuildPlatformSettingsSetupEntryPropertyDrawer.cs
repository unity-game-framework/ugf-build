using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UnityEditor;
using UnityEngine;

namespace UGF.Build.Editor
{
    [CustomPropertyDrawer(typeof(BuildPlatformSettings.SetupEntry), true)]
    internal class BuildPlatformSettingsSetupEntryPropertyDrawer : PropertyDrawerBase
    {
        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            SerializedProperty propertyName = serializedProperty.FindPropertyRelative("m_name");
            SerializedProperty propertySetup = serializedProperty.FindPropertyRelative("m_setup");

            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;
            float width = EditorGUIUtility.labelWidth;

            var rectName = new Rect(position.x - height, position.y, width + height - space, position.height);
            var rectField = new Rect(rectName.xMax + space, position.y, position.width - width, position.height);

            EditorGUI.PropertyField(rectName, propertyName, GUIContent.none);
            EditorGUI.PropertyField(rectField, propertySetup, GUIContent.none);
        }

        public override float GetPropertyHeight(SerializedProperty serializedProperty, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
