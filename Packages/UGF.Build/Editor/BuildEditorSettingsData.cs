﻿using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Runtime.IMGUI.PlatformSettings;
using UnityEngine;

namespace UGF.Build.Editor
{
    public class BuildEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private bool m_logEnable = true;
        [SerializeField] private LogType m_logFilter = LogType.Log;
        [SerializeField] private string m_setupNameEnvironmentVariableName = "BUILD_SETUP";
        [SerializeField] private PlatformSettings<BuildPlatformSettings> m_platforms = new PlatformSettings<BuildPlatformSettings>();

        public bool LogEnable { get { return m_logEnable; } set { m_logEnable = value; } }
        public LogType LogFilter { get { return m_logFilter; } set { m_logFilter = value; } }
        public string SetupNameEnvironmentVariableName { get { return m_setupNameEnvironmentVariableName; } set { m_setupNameEnvironmentVariableName = value; } }
        public PlatformSettings<BuildPlatformSettings> Platforms { get { return m_platforms; } }
    }
}
