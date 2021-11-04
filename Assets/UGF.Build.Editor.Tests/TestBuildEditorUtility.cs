using NUnit.Framework;
using UGF.EditorTools.Editor.Yaml;
using UnityEditor.Build.Reporting;

namespace UGF.Build.Editor.Tests
{
    public class TestBuildEditorUtility
    {
        [Test]
        public void TryGetBuildReport()
        {
            var result = EditorYamlUtility.FromYamlAtPath<BuildReport>("Assets/StreamingAssets/LastBuild.buildreport");

            Assert.NotNull(result);
            Assert.IsInstanceOf<BuildReport>(result);
        }
    }
}
