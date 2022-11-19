using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.ReleaseNotes
{
    public class ReleaseNoteStep : BuildStep
    {
        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            context.Add(new ReleaseNoteData());
        }
    }
}
