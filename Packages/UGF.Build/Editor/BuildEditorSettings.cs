using System;
using UGF.CustomSettings.Editor;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
using UnityEditor;

namespace UGF.Build.Editor
{
    public static class BuildEditorSettings
    {
        public static CustomSettingsEditorPackage<BuildEditorSettingsData> Settings { get; } = new CustomSettingsEditorPackage<BuildEditorSettingsData>
        (
            "UGF.Build",
            nameof(BuildEditorSettings)
        );

        public static BuildSetupAsset GetSetup(BuildTargetGroup buildTargetGroup, string name)
        {
            return TryGetSetup(buildTargetGroup, name, out BuildSetupAsset setup) ? setup : throw new ArgumentException($@"Setup not found by the specified group and name: '{buildTargetGroup}', '{name}'.");
        }

        public static bool TryGetSetup(BuildTargetGroup buildTargetGroup, string name, out BuildSetupAsset setup)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            BuildEditorSettingsData data = Settings.GetData();

            setup = null;
            return data.Platforms.TryGetSettings(buildTargetGroup, out BuildPlatformSettings settings) && BuildEditorUtility.TryGetSetup(settings, name, out setup);
        }

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<BuildEditorSettingsData>("Project/Unity Game Framework/Build", Settings, SettingsScope.Project);
        }
    }
}
