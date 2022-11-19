using UnityEngine;

namespace UGF.Build.Editor.UnityCloud.Android
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Unity Cloud Android Version Code Step", order = 2000)]
    public class UnityCloudAndroidVersionCodeStepAsset : BuildStepAsset
    {
        protected override IBuildStep OnBuild()
        {
            return new UnityCloudAndroidVersionCodeStep();
        }
    }
}
