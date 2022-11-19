using System.Collections.Generic;
using UnityEngine;

namespace UGF.Build.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Build Step Collection List", order = 2000)]
    public class BuildStepCollectionListAsset : BuildStepCollectionAsset
    {
        [SerializeField] private List<BuildStepAsset> m_steps = new List<BuildStepAsset>();

        public List<BuildStepAsset> Steps { get { return m_steps; } }

        protected override void OnGetSteps(ICollection<IBuildStep> steps)
        {
            for (int i = 0; i < m_steps.Count; i++)
            {
                BuildStepAsset step = m_steps[i];

                steps.Add(step.Build());
            }
        }
    }
}
