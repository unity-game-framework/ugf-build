using UGF.CustomSettings.Editor;
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

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<BuildEditorSettingsData>("Project/Unity Game Framework/Build", Settings, SettingsScope.Project);
        }
    }
}
