using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Build.Editor.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestBuildStepAsset")]
    public class TestBuildStepAsset : BuildStepAsset
    {
        protected override IBuildStep OnBuild()
        {
            return new TestBuildStep(name);
        }
    }

    public class TestBuildStep : BuildStep
    {
        public TestBuildStep(string name) : base(name)
        {
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
        }
    }
}
