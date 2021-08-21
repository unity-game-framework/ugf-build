using System;
using UnityEngine;

namespace UGF.Build.Runtime.UnityCloud
{
    public static class UnityCloudBuildUtility
    {
        private const string MANIFEST_RESOURCES_NAME = "UnityCloudBuildManifest.json";

        public static bool HasManifest()
        {
            return Resources.Load(MANIFEST_RESOURCES_NAME) != null;
        }

        public static UnityCloudBuildManifest GetManifest()
        {
            var asset = Resources.Load<TextAsset>(MANIFEST_RESOURCES_NAME);

            if (asset == null) throw new ArgumentNullException(nameof(asset), "Unity Cloud Build Manifest not found at resources.");

            string text = asset.text;
            var manifest = JsonUtility.FromJson<UnityCloudBuildManifest>(text);

            return manifest ?? throw new ArgumentNullException(nameof(manifest), "Unity Cloud Build Manifest can not be created.");
        }
    }
}
