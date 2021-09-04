using System;
using UGF.Build.Runtime.UnityCloud;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Build.Editor.UnityCloud
{
    public static class UnityCloudBuildEditorUtility
    {
        private const string MANIFEST_RESOURCES_NAME = "UnityCloudBuildManifest.scriptable";

        public static bool HasManifest()
        {
            return Resources.Load(MANIFEST_RESOURCES_NAME) != null;
        }

        public static UnityCloudBuildManifest GetManifest()
        {
            Object asset = Resources.Load(MANIFEST_RESOURCES_NAME);

            if (asset == null) throw new ArgumentNullException(nameof(asset), "Unity Cloud Build Manifest not found at resources.");

            string text = JsonUtility.ToJson(asset);
            var container = JsonUtility.FromJson<UnityCloudBuildManifestContainer>(text);
            var manifest = JsonUtility.FromJson<UnityCloudBuildManifest>(container.ManifestJson);

            return manifest ?? throw new ArgumentNullException(nameof(manifest), "Unity Cloud Build Manifest can not be created.");
        }
    }
}
