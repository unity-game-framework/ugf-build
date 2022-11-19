using UGF.Build.Editor.ReleaseNotes;
using UGF.Build.Runtime.UnityCloud;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.UnityCloud
{
    public class UnityCloudBuildManifestReleaseNoteStep : BuildStep
    {
        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var releaseNote = context.Get<ReleaseNoteData>();
            var manifest = context.Get<UnityCloudBuildManifest>();

            releaseNote.AddData(manifest);
        }
    }
}
