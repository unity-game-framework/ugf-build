using UnityEngine;

namespace UGF.Build.Editor.Player
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Player Version External Step", order = 2000)]
    public class PlayerVersionExternalStepAsset : BuildStepAsset
    {
        [SerializeField] private string m_path;
        [SerializeField] private bool m_setPlayerBundlerVersion = true;

        public string Path { get { return m_path; } set { m_path = value; } }
        public bool SetPlayerBundlerVersion { get { return m_setPlayerBundlerVersion; } set { m_setPlayerBundlerVersion = value; } }

        protected override IBuildStep OnBuild()
        {
            return new PlayerVersionExternalStep(m_path, m_setPlayerBundlerVersion);
        }
    }
}
