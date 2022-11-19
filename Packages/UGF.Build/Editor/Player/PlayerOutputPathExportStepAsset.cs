using UnityEngine;

namespace UGF.Build.Editor.Player
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Player Output Path Export Step", order = 2000)]
    public class PlayerOutputPathExportStepAsset : BuildStepAsset
    {
        [SerializeField] private string m_path;

        public string Path { get { return m_path; } set { m_path = value; } }

        protected override IBuildStep OnBuild()
        {
            return new PlayerOutputPathExportStep(m_path);
        }
    }
}
