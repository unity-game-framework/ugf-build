using UnityEngine;

namespace UGF.Build.Editor.UnityCloud
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Unity Cloud Build Manifest Release Note Step", order = 2000)]
    public class UnityCloudBuildManifestReleaseNoteStepAsset : BuildStepAsset
    {
        protected override IBuildStep OnBuild()
        {
            return new UnityCloudBuildManifestReleaseNoteStep();
        }
    }
}
