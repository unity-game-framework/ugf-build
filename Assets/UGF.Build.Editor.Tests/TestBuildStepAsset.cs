using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;
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
            Debug.Log($"Execute Build Step: '{Name}'.");
        }
    }

    internal static class TestBuildExecute
    {
        [MenuItem("Tests/TestBuildExecute")]
        private static void Menu()
        {
            BuildEditorUtility.Execute(BuildTargetGroup.Standalone, "Test", new Context());
        }
    }
}
