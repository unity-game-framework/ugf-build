using JetBrains.Annotations;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.BatchMode
{
    public static class BatchModeBuild
    {
        [UsedImplicitly]
        public static void PreExport()
        {
            BuildEditorUtility.ExecutePreExport(new Context());
        }

        [UsedImplicitly]
        public static void PostExport()
        {
            BuildEditorUtility.ExecutePostExport(new Context());
        }
    }
}
