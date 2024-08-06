using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor.Files
{
    [CustomEditor(typeof(FileStepAsset), true)]
    internal class FileStepAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listCopy;

        private void OnEnable()
        {
            m_listCopy = new ReorderableListDrawer(serializedObject.FindProperty("m_copy"))
            {
                DisplayElementFoldout = false
            };

            m_listCopy.Enable();
        }

        private void OnDisable()
        {
            m_listCopy.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listCopy.DrawGUILayout();
            }
        }
    }
}
