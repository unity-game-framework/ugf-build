using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Build.Editor
{
    [Serializable]
    public class BuildPlatformSettings
    {
        [SerializeField] private List<ProfileEntry> m_profiles = new List<ProfileEntry>();

        public List<ProfileEntry> Profiles { get { return m_profiles; } }

        [Serializable]
        public struct ProfileEntry
        {
            [SerializeField] private string m_name;
            [SerializeField] private BuildProfileAsset m_profile;

            public string Name { get { return m_name; } set { m_name = value; } }
            public BuildProfileAsset Profile { get { return m_profile; } set { m_profile = value; } }
        }
    }
}
