using System;
using UnityEditor;

namespace UGF.Build.Editor
{
    public static class BuildEditorUtility
    {
        public static void Build(BuildTarget buildTarget, string profileName)
        {
            if (string.IsNullOrEmpty(profileName)) throw new ArgumentException("Value cannot be null or empty.", nameof(profileName));
        }

        public static bool TryGetSetup(BuildPlatformSettings settings, string name, out BuildSetupAsset setup)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            for (int i = 0; i < settings.Setups.Count; i++)
            {
                BuildPlatformSettings.SetupEntry entry = settings.Setups[i];

                if (entry.Name == name)
                {
                    setup = entry.Setup;
                    return true;
                }
            }

            setup = null;
            return false;
        }
    }
}
