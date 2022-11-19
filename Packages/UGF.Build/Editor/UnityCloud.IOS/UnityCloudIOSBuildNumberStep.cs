using System;
using UGF.Build.Runtime.UnityCloud;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor.UnityCloud.IOS
{
    public class UnityCloudIOSBuildNumberStep : BuildStep
    {
        public string Format { get; }

        public UnityCloudIOSBuildNumberStep(string format)
        {
            if (string.IsNullOrEmpty(format)) throw new ArgumentException("Value cannot be null or empty.", nameof(format));

            Format = format;
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var manifest = context.Get<UnityCloudBuildManifest>();

            PlayerSettings.iOS.buildNumber = string.Format(Format, PlayerSettings.bundleVersion, manifest.BuildNumber);

            Log.Info("Unity Cloud iOS build number set", new { PlayerSettings.iOS.buildNumber });
        }
    }
}
