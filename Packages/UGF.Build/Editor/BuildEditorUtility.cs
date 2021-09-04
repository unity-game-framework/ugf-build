using System;
using System.Collections.Generic;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor
{
    public static class BuildEditorUtility
    {
        public static void ExecutePreExport(IContext context)
        {
            BuildEditorSettingsData settings = BuildEditorSettings.Settings.GetData();
            string name = GetSetupNameFromEnvironmentVariables(settings.PreExportSetupNameEnvironmentVariable);

            Execute(name, context);
        }

        public static void ExecutePostExport(IContext context)
        {
            BuildEditorSettingsData settings = BuildEditorSettings.Settings.GetData();
            string name = GetSetupNameFromEnvironmentVariables(settings.PostExportSetupNameEnvironmentVariable);

            Execute(name, context);
        }

        public static void Execute(string name, IContext context)
        {
            Execute(EditorUserBuildSettings.selectedBuildTargetGroup, name, context);
        }

        public static void Execute(BuildTargetGroup buildTargetGroup, string name, IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            BuildEditorSettingsData settings = BuildEditorSettings.Settings.GetData();

            using (new BuildLogScope(settings.LogEnable, settings.LogFilter))
            {
                IBuildSetup setup = GetSetup(buildTargetGroup, name);

                setup.Execute(context);
            }
        }

        public static IBuildSetup GetSetup(BuildTargetGroup buildTargetGroup, string name)
        {
            BuildSetupAsset asset = GetSetupAsset(buildTargetGroup, name);
            IBuildSetup setup = asset.Build();

            return setup;
        }

        public static BuildSetupAsset GetSetupAsset(BuildTargetGroup buildTargetGroup, string name)
        {
            return TryGetSetupAsset(buildTargetGroup, name, out BuildSetupAsset setup) ? setup : throw new ArgumentException($@"Setup not found by the specified group and name: '{buildTargetGroup}', '{name}'.");
        }

        public static bool TryGetSetupAsset(BuildTargetGroup buildTargetGroup, string name, out BuildSetupAsset setup)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            BuildEditorSettingsData data = BuildEditorSettings.Settings.GetData();

            setup = null;
            return data.Platforms.TryGetSettings(buildTargetGroup, out BuildPlatformSettings settings) && TryGetSetup(settings, name, out setup);
        }

        public static string GetSetupNameFromEnvironmentVariables(string environmentVariableName)
        {
            return TryGetSetupNameFromEnvironmentVariables(environmentVariableName, out string name) ? name : throw new ArgumentException("Environment variable not found.");
        }

        public static bool TryGetSetupNameFromEnvironmentVariables(string environmentVariableName, out string name)
        {
            if (string.IsNullOrEmpty(environmentVariableName)) throw new ArgumentException("Value cannot be null or empty.", nameof(environmentVariableName));

            name = Environment.GetEnvironmentVariable(environmentVariableName);
            return !string.IsNullOrEmpty(name);
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

        public static bool TryGetArgumentValues(IReadOnlyList<string> arguments, string name, out string value)
        {
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            for (int i = 0; i < arguments.Count - 1; i++)
            {
                value = arguments[i];

                if (value == name)
                {
                    value = arguments[i + 1];
                    return true;
                }
            }

            value = null;
            return false;
        }
    }
}
