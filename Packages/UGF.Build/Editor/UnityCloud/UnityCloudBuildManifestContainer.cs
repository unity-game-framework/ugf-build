using System;
using UnityEngine;

namespace UGF.Build.Editor.UnityCloud
{
    [Serializable]
    internal class UnityCloudBuildManifestContainer
    {
        [SerializeField] private string m_manifestJson;

        public string ManifestJson { get { return m_manifestJson; } set { m_manifestJson = value; } }
    }
}
