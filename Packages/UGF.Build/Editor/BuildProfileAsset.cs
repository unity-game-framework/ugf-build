using System.Collections.Generic;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UGF.EditorTools.Runtime.IMGUI.EnabledProperty;
using UnityEngine;

namespace UGF.Build.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Build Profile", order = 2000)]
    public class BuildProfileAsset : BuilderAsset<IBuildProfile>
    {
        [SerializeField] private List<EnabledProperty<AssetReference<BuildStepAsset>>> m_steps = new List<EnabledProperty<AssetReference<BuildStepAsset>>>();

        public List<EnabledProperty<AssetReference<BuildStepAsset>>> Steps { get { return m_steps; } }

        protected override IBuildProfile OnBuild()
        {
            var profile = new BuildProfile(name);

            for (int i = 0; i < m_steps.Count; i++)
            {
                EnabledProperty<AssetReference<BuildStepAsset>> element = m_steps[i];

                if (element.Enabled)
                {
                    AssetReference<BuildStepAsset> reference = element.Value;
                    IBuildStep step = reference.Asset.Build();

                    profile.Steps.Add(reference.Guid, step);
                    profile.StepsOrder.Add(reference.Guid);
                }
            }

            return profile;
        }
    }
}
