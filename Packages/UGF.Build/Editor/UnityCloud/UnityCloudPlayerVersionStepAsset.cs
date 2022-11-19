using UnityEngine;

namespace UGF.Build.Editor.UnityCloud
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Unity Cloud Player Version Step", order = 2000)]
    public class UnityCloudPlayerVersionStepAsset : BuildStepAsset
    {
        [SerializeField] private string m_format = "{0}.{1}";

        public string Format { get { return m_format; } set { m_format = value; } }

        protected override IBuildStep OnBuild()
        {
            return new UnityCloudPlayerVersionStep(m_format);
        }
    }
}
