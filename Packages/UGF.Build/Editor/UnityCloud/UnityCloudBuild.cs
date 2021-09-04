using JetBrains.Annotations;
using UGF.Build.Runtime.UnityCloud;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.UnityCloud
{
    public static class UnityCloudBuild
    {
        [UsedImplicitly]
        public static void PreExport()
        {
            UnityCloudBuildManifest manifest = UnityCloudBuildEditorUtility.GetManifest();

            BuildEditorUtility.ExecutePreExport(new Context { manifest });
        }

        [UsedImplicitly]
        public static void PostExport()
        {
            UnityCloudBuildManifest manifest = UnityCloudBuildEditorUtility.GetManifest();

            BuildEditorUtility.ExecutePostExport(new Context { manifest });
        }
    }
}
