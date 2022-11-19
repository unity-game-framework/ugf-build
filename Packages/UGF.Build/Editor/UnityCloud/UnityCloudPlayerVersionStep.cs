using System;
using UGF.Build.Runtime.UnityCloud;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor.UnityCloud
{
    public class UnityCloudPlayerVersionStep : BuildStep
    {
        public string Format { get; }

        public UnityCloudPlayerVersionStep(string format)
        {
            if (string.IsNullOrEmpty(format)) throw new ArgumentException("Value cannot be null or empty.", nameof(format));

            Format = format;
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var manifest = context.Get<UnityCloudBuildManifest>();
            string version = PlayerSettings.bundleVersion;

            if (string.IsNullOrEmpty(version)) throw new ArgumentException("Player bundle version can not be null or empty.");

            PlayerSettings.bundleVersion = string.Format(Format, version, manifest.BuildNumber);
        }
    }
}
