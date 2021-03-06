using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor
{
    [CustomEditor(typeof(BuildSetupAsset), true)]
    internal class BuildSetupAssetEditor : UnityEditor.Editor
    {
        private BuildSetupAssetStepsDrawer m_listSteps;

        private void OnEnable()
        {
            m_listSteps = new BuildSetupAssetStepsDrawer(serializedObject.FindProperty("m_steps"));
            m_listSteps.Enable();
        }

        private void OnDisable()
        {
            m_listSteps.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listSteps.DrawGUILayout();
                m_listSteps.DrawSelectedLayout();
            }
        }
    }
}
