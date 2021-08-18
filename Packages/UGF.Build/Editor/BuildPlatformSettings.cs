using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Build.Editor
{
    [Serializable]
    public class BuildPlatformSettings
    {
        [SerializeField] private List<SetupEntry> m_setups = new List<SetupEntry>();

        public List<SetupEntry> Setups { get { return m_setups; } }

        [Serializable]
        public struct SetupEntry
        {
            [SerializeField] private string m_name;
            [SerializeField] private BuildSetupAsset m_setup;

            public string Name { get { return m_name; } set { m_name = value; } }
            public BuildSetupAsset Setup { get { return m_setup; } set { m_setup = value; } }
        }
    }
}
