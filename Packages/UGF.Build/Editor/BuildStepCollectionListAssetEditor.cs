using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor
{
    [CustomEditor(typeof(BuildStepCollectionListAsset), true)]
    internal class BuildStepCollectionListAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listSteps;
        private ReorderableListSelectionDrawerByElement m_listStepsSelection;

        private void OnEnable()
        {
            m_listSteps = new ReorderableListDrawer(serializedObject.FindProperty("m_steps"));

            m_listStepsSelection = new ReorderableListSelectionDrawerByElement(m_listSteps)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listSteps.Enable();
            m_listStepsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listSteps.Disable();
            m_listStepsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listSteps.DrawGUILayout();
                m_listStepsSelection.DrawGUILayout();
            }
        }
    }
}
