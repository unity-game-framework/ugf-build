using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor
{
    [CustomEditor(typeof(BuildEditorSettingsData), true)]
    internal class BuildEditorSettingsDataEditor : UnityEditor.Editor
    {
        private readonly BuildEditorSettingsDataPlatformsDrawer m_platformsDrawer = new BuildEditorSettingsDataPlatformsDrawer();
        private SerializedProperty m_propertyLogEnable;
        private SerializedProperty m_propertyLogFilter;
        private SerializedProperty m_propertySetupNameEnvironmentVariableName;
        private SerializedProperty m_propertyPlatformsGroups;

        private void OnEnable()
        {
            m_platformsDrawer.Enable();

            m_propertyLogEnable = serializedObject.FindProperty("m_logEnable");
            m_propertyLogFilter = serializedObject.FindProperty("m_logFilter");
            m_propertySetupNameEnvironmentVariableName = serializedObject.FindProperty("m_setupNameEnvironmentVariableName");
            m_propertyPlatformsGroups = serializedObject.FindProperty("m_platforms.m_groups");
        }

        private void OnDisable()
        {
            m_platformsDrawer.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorGUILayout.PropertyField(m_propertyLogEnable);
                EditorGUILayout.PropertyField(m_propertyLogFilter);
                EditorGUILayout.PropertyField(m_propertySetupNameEnvironmentVariableName);
                EditorGUILayout.Space();

                m_platformsDrawer.DrawGUILayout(m_propertyPlatformsGroups);
            }
        }
    }
}
