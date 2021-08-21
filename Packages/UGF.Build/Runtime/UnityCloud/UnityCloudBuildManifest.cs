using System;
using UnityEngine;

namespace UGF.Build.Runtime.UnityCloud
{
    [Serializable]
    public class UnityCloudBuildManifest
    {
        [SerializeField] private string scmCommitId;
        [SerializeField] private string scmBranch;
        [SerializeField] private string buildNumber;
        [SerializeField] private string buildStartTime;
        [SerializeField] private string projectId;
        [SerializeField] private string bundleId;
        [SerializeField] private string unityVersion;
        [SerializeField] private string xcodeVersion;
        [SerializeField] private string cloudBuildTargetName;

        public string ScmCommitId { get { return scmCommitId; } set { scmCommitId = value; } }
        public string ScmBranch { get { return scmBranch; } set { scmBranch = value; } }
        public string BuildNumber { get { return buildNumber; } set { buildNumber = value; } }
        public string BuildStartTime { get { return buildStartTime; } set { buildStartTime = value; } }
        public string ProjectId { get { return projectId; } set { projectId = value; } }
        public string BundleId { get { return bundleId; } set { bundleId = value; } }
        public string UnityVersion { get { return unityVersion; } set { unityVersion = value; } }
        public string XcodeVersion { get { return xcodeVersion; } set { xcodeVersion = value; } }
        public string CloudBuildTargetName { get { return cloudBuildTargetName; } set { cloudBuildTargetName = value; } }
    }
}
