using System;
using System.Collections.Generic;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.EditorTools.Editor.Platforms;
using UnityEditor;
using UnityEngine;

namespace UGF.Build.Editor
{
    internal class BuildEditorSettingsDataPlatformsDrawer : PlatformSettingsDrawer
    {
        private readonly Dictionary<string, ReorderableListDrawer> m_listDrawers = new Dictionary<string, ReorderableListDrawer>();
        private static float m_padding = 5F;

        public BuildEditorSettingsDataPlatformsDrawer()
        {
            AllowEmptySettings = false;
            AutoSettingsInstanceCreation = true;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            AddPlatformAllAvailable();

            for (int i = 0; i < PlatformEditorUtility.PlatformsAllAvailable.Count; i++)
            {
                PlatformInfo platform = PlatformEditorUtility.PlatformsAllAvailable[i];
                string name = platform.BuildTargetGroup.ToString();

                AddGroupType(name, typeof(BuildPlatformSettings));
            }

            foreach (KeyValuePair<string, ReorderableListDrawer> pair in m_listDrawers)
            {
                pair.Value.Enable();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            ClearGroups();
            ClearGroupTypes();

            foreach (KeyValuePair<string, ReorderableListDrawer> pair in m_listDrawers)
            {
                pair.Value.Disable();
            }

            m_listDrawers.Clear();
        }

        protected override void OnDrawSettings(Rect position, SerializedProperty propertyGroups, string name)
        {
            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            PlatformInfo platform = GetPlatformInfo(name);
            SerializedProperty propertySettings = OnGetSettings(propertyGroups, name);

            using (new LabelWidthChangeScope(-m_padding))
            {
                var rectPlatformName = new Rect(position.x, position.y, position.width, height);
                var rectSetups = new Rect(position.x, rectPlatformName.yMax + space, position.width, height);

                EditorGUI.LabelField(rectPlatformName, $"Settings for {platform.Label.text}");

                ReorderableListDrawer drawer = GetListDrawer(name, propertySettings);

                drawer.DrawGUI(rectSetups);
            }
        }

        protected override float OnGetSettingsHeight(SerializedProperty propertyGroups)
        {
            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            string name = GetSelectedGroupName();
            SerializedProperty propertySettings = OnGetSettings(propertyGroups, name);
            ReorderableListDrawer drawer = GetListDrawer(name, propertySettings);

            float heightSetups = drawer.SerializedProperty.isExpanded ? drawer.GetHeight() : height;

            return height + space * 2F + heightSetups + m_padding * 2F;
        }

        protected override void OnCreateSettings(SerializedProperty propertyGroups, string name, SerializedProperty propertySettings)
        {
            base.OnCreateSettings(propertyGroups, name, propertySettings);

            GetListDrawer(name, propertySettings);
        }

        private PlatformInfo GetPlatformInfo(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            var buildTargetGroup = (BuildTargetGroup)Enum.Parse(typeof(BuildTargetGroup), name, true);
            PlatformInfo platform = PlatformEditorUtility.GetPlatform(buildTargetGroup);

            return platform;
        }

        private ReorderableListDrawer GetListDrawer(string name, SerializedProperty propertySettings)
        {
            if (!m_listDrawers.TryGetValue(name, out ReorderableListDrawer drawer))
            {
                SerializedProperty propertySetups = propertySettings.FindPropertyRelative("m_setups");

                drawer = new ReorderableListDrawer(propertySetups);

                m_listDrawers.Add(name, drawer);
            }

            return drawer;
        }
    }
}
