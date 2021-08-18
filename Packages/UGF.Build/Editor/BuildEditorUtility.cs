using System;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor
{
    public static class BuildEditorUtility
    {
        public static void Execute(BuildTargetGroup buildTargetGroup, string name, IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            IBuildSetup setup = GetSetup(buildTargetGroup, name);

            setup.Execute(context);
        }

        public static IBuildSetup GetSetup(BuildTargetGroup buildTargetGroup, string name)
        {
            BuildSetupAsset asset = BuildEditorSettings.GetSetup(buildTargetGroup, name);
            IBuildSetup setup = asset.Build();

            return setup;
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
