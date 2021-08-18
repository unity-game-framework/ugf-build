using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UnityEditor;
using UnityEngine;

namespace UGF.Build.Editor
{
    [CustomPropertyDrawer(typeof(BuildPlatformSettings.ProfileEntry), true)]
    internal class BuildPlatformSettingsProfileEntryPropertyDrawer : PropertyDrawerBase
    {
        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            SerializedProperty propertyName = serializedProperty.FindPropertyRelative("m_name");
            SerializedProperty propertyProfile = serializedProperty.FindPropertyRelative("m_profile");

            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;
            float width = EditorGUIUtility.labelWidth;

            var rectName = new Rect(position.x - height, position.y, width + height - space, position.height);
            var rectField = new Rect(rectName.xMax + space, position.y, position.width - width, position.height);

            EditorGUI.PropertyField(rectName, propertyName, GUIContent.none);
            EditorGUI.PropertyField(rectField, propertyProfile, GUIContent.none);
        }

        public override float GetPropertyHeight(SerializedProperty serializedProperty, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
