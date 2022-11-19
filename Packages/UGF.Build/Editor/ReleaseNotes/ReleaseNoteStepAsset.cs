using UnityEngine;

namespace UGF.Build.Editor.ReleaseNotes
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Release Note Step", order = 2000)]
    public class ReleaseNoteStepAsset : BuildStepAsset
    {
        protected override IBuildStep OnBuild()
        {
            return new ReleaseNoteStep();
        }
    }
}
