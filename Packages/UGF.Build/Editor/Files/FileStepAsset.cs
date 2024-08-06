using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Build.Editor.Files
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/File Step", order = 2000)]
    public class FileStepAsset : BuildStepAsset
    {
        [SerializeField] private List<CopyData> m_copy = new List<CopyData>();

        public List<CopyData> Copy { get { return m_copy; } }

        [Serializable]
        public struct CopyData
        {
            [SerializeField] private string m_from;
            [SerializeField] private string m_to;

            public string From { get { return m_from; } set { m_from = value; } }
            public string To { get { return m_to; } set { m_to = value; } }
        }

        protected override IBuildStep OnBuild()
        {
            var copy = new FileStep.CopyData[m_copy.Count];

            for (int i = 0; i < m_copy.Count; i++)
            {
                CopyData copyData = m_copy[i];

                copy[i] = new FileStep.CopyData(copyData.From, copyData.To);
            }

            return new FileStep(copy);
        }
    }
}
