using JetBrains.Annotations;

namespace UGF.Build.Editor.BatchMode
{
    public static class BatchModeBuild
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
