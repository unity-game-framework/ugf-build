using System.Collections.Generic;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.IMGUI.EnabledProperty;
using UnityEngine;

namespace UGF.Build.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Build Setup", order = 2000)]
    public class BuildSetupAsset : BuilderAsset<IBuildSetup>
    {
        [SerializeField] private List<EnabledProperty<BuildStepAsset>> m_steps = new List<EnabledProperty<BuildStepAsset>>();

        public List<EnabledProperty<BuildStepAsset>> Steps { get { return m_steps; } }

        protected override IBuildSetup OnBuild()
        {
            var profile = new BuildSetup(name);

            for (int i = 0; i < m_steps.Count; i++)
            {
                EnabledProperty<BuildStepAsset> element = m_steps[i];

                if (element.Enabled)
                {
                    IBuildStep step = element.Value.Build();

                    profile.Steps.Add(step);
                }
            }

            return profile;
        }
    }
}
