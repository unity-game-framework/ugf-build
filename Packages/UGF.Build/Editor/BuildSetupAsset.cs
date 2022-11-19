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
        [SerializeField] private List<BuildStepCollectionAsset> m_collections = new List<BuildStepCollectionAsset>();

        public List<EnabledProperty<BuildStepAsset>> Steps { get { return m_steps; } }
        public List<BuildStepCollectionAsset> Collections { get { return m_collections; } }

        protected override IBuildSetup OnBuild()
        {
            var setup = new BuildSetup(name);

            for (int i = 0; i < m_steps.Count; i++)
            {
                EnabledProperty<BuildStepAsset> stepProperty = m_steps[i];

                if (stepProperty.Enabled)
                {
                    IBuildStep step = stepProperty.Value.Build();

                    setup.Steps.Add(step);
                }
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                BuildStepCollectionAsset collection = m_collections[i];

                collection.GetSteps(setup.Steps);
            }

            return setup;
        }
    }
}
