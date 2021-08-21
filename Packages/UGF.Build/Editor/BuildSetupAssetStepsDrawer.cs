using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.EnabledProperty;
using UnityEditor;

namespace UGF.Build.Editor
{
    internal class BuildSetupAssetStepsDrawer : EnabledPropertyListDrawer
    {
        public EditorDrawer Drawer { get; } = new EditorDrawer
        {
            DisplayTitlebar = true
        };

        public BuildSetupAssetStepsDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            Drawer.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            Drawer.Disable();
        }

        protected override void OnRemove()
        {
            base.OnRemove();

            UpdateSelection();
        }

        protected override void OnSelect()
        {
            base.OnSelect();

            UpdateSelection();
        }

        public void DrawSelectedLayout()
        {
            Drawer.DrawGUILayout();
        }

        private void UpdateSelection()
        {
            if (List.index >= 0 && List.index < List.count)
            {
                SerializedProperty propertyElement = SerializedProperty.GetArrayElementAtIndex(List.index);
                SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_value");

                if (propertyValue.objectReferenceValue != null)
                {
                    Drawer.Set(propertyValue.objectReferenceValue);
                }
                else
                {
                    Drawer.Clear();
                }
            }
            else
            {
                Drawer.Clear();
            }
        }
    }
}
