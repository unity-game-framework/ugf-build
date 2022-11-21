using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;

namespace UGF.Build.Editor.Player
{
    [CustomEditor(typeof(PlayerScenesStepAsset), true)]
    internal class PlayerScenesStepAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listScenes;

        private void OnEnable()
        {
            m_listScenes = new ReorderableListDrawer(serializedObject.FindProperty("m_scenes"))
            {
                DisplayAsSingleLine = true
            };

            m_listScenes.Enable();
        }

        private void OnDisable()
        {
            m_listScenes.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listScenes.DrawGUILayout();
            }
        }
    }
}
