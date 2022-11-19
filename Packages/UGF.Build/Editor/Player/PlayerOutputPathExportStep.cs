using System;
using System.IO;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor.Build.Reporting;

namespace UGF.Build.Editor.Player
{
    public class PlayerOutputPathExportStep : BuildStep
    {
        public string Path { get; }

        public PlayerOutputPathExportStep(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            Path = path;
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var report = context.Get<BuildReport>();

            File.WriteAllText(Path, report.summary.outputPath);
        }
    }
}
