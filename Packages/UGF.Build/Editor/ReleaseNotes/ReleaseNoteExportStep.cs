using System;
using System.IO;
using System.Text;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.ReleaseNotes
{
    public class ReleaseNoteExportStep : BuildStep
    {
        public string Path { get; }
        public Encoding Encoding { get; }

        public ReleaseNoteExportStep(string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            Path = path;
            Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var data = context.Get<ReleaseNoteData>();

            File.WriteAllText(Path, data.GetString(), Encoding);

            Log.Info("Release Notes exported", new { Path });
        }
    }
}
