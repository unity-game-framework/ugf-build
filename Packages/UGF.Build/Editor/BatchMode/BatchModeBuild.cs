using JetBrains.Annotations;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor.Build.Reporting;

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
            var context = new Context();

            if (BuildEditorUtility.TryGetBuildReport(out BuildReport report))
            {
                context.Add(report);
            }

            BuildEditorUtility.ExecutePostExport(new Context());
        }
    }
}
