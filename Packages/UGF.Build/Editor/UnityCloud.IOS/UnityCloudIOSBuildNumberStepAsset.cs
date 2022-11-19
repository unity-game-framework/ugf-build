using UnityEngine;

namespace UGF.Build.Editor.UnityCloud.IOS
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Unity Cloud iOS Build Number Step", order = 2000)]
    public class UnityCloudIOSBuildNumberStepAsset : BuildStepAsset
    {
        [SerializeField] private string m_format = "{0}.{1}";

        public string Format { get { return m_format; } set { m_format = value; } }

        protected override IBuildStep OnBuild()
        {
            return new UnityCloudIOSBuildNumberStep(m_format);
        }
    }
}
