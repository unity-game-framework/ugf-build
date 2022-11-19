using UGF.RuntimeTools.Runtime.Encodings;
using UnityEngine;

namespace UGF.Build.Editor.ReleaseNotes
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Release Note Export Step", order = 2000)]
    public class ReleaseNoteExportStepAsset : BuildStepAsset
    {
        [SerializeField] private string m_path;
        [SerializeField] private EncodingType m_encodingType = EncodingType.Default;

        public string Path { get { return m_path; } set { m_path = value; } }
        public EncodingType EncodingType { get { return m_encodingType; } set { m_encodingType = value; } }

        protected override IBuildStep OnBuild()
        {
            return new ReleaseNoteExportStep(m_path, EncodingUtility.GetEncoding(m_encodingType));
        }
    }
}
