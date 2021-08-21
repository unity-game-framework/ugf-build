using JetBrains.Annotations;

namespace UGF.Build.Editor.UnityCloud
{
    public static class UnityCloudBuild
    {
        [UsedImplicitly]
        public static void PreExport()
        {
            BuildEditorUtility.Execute();
        }

        [UsedImplicitly]
        public static void PostExport()
        {
            BuildEditorUtility.Execute();
        }
    }
}
