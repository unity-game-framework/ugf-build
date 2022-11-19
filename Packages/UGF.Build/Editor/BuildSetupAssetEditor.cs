using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.EnabledProperty;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor
{
    [CustomEditor(typeof(BuildSetupAsset), true)]
    internal class BuildSetupAssetEditor : UnityEditor.Editor
    {
        private EnabledPropertyListDrawer m_listSteps;
        private ReorderableListSelectionDrawerByPath m_listStepsSelection;
        private ReorderableListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByElement m_listCollectionsSelection;

        private void OnEnable()
        {
            m_listSteps = new EnabledPropertyListDrawer(serializedObject.FindProperty("m_steps"));

            m_listStepsSelection = new ReorderableListSelectionDrawerByPath(m_listSteps, "m_value")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listCollections = new ReorderableListDrawer(serializedObject.FindProperty("m_collections"));

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByElement(m_listCollections)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listSteps.Enable();
            m_listStepsSelection.Enable();
            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listSteps.Disable();
            m_listStepsSelection.Disable();
            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listSteps.DrawGUILayout();
                m_listCollections.DrawGUILayout();

                m_listStepsSelection.DrawGUILayout();
                m_listCollectionsSelection.DrawGUILayout();
            }
        }
    }
}
