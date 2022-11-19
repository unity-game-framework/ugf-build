using System;
using UGF.Build.Runtime.UnityCloud;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor.UnityCloud.Android
{
    public class UnityCloudAndroidVersionCodeStep : BuildStep
    {
        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var manifest = context.Get<UnityCloudBuildManifest>();

            if (!int.TryParse(manifest.BuildNumber, out int number))
            {
                throw new ArgumentException($"Failed to parse Unity Cloud Manifest build number: '{manifest.BuildNumber}'.");
            }

            PlayerSettings.Android.bundleVersionCode = number;

            Log.Info("Unity Cloud Android bundle version code set", new { PlayerSettings.Android.bundleVersionCode });
        }
    }
}
