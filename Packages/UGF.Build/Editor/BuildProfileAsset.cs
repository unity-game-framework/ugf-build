using System.Collections.Generic;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Build.Editor
{
    public class BuildProfileAsset : BuilderAsset<IBuildProfile>
    {
        [SerializeField] private List<AssetReference<BuildStepAsset>> m_steps = new List<AssetReference<BuildStepAsset>>();

        public List<AssetReference<BuildStepAsset>> Steps { get { return m_steps; } }

        protected override IBuildProfile OnBuild()
        {
            var profile = new BuildProfile(name);

            for (int i = 0; i < m_steps.Count; i++)
            {
                AssetReference<BuildStepAsset> reference = m_steps[i];
                IBuildStep step = reference.Asset.Build();

                profile.Steps.Add(reference.Guid, step);
                profile.StepsOrder.Add(reference.Guid);
            }

            return profile;
        }
    }
}
