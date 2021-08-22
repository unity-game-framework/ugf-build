using System;
using UnityEngine;

namespace UGF.Build.Editor
{
    public readonly struct BuildLogScope : IDisposable
    {
        private readonly bool m_enable;
        private readonly LogType m_filter;

        public BuildLogScope(bool enable, LogType filter)
        {
            m_enable = Debug.unityLogger.logEnabled;
            m_filter = Debug.unityLogger.filterLogType;

            Debug.unityLogger.logEnabled = enable;
            Debug.unityLogger.filterLogType = filter;
        }

        public void Dispose()
        {
            Debug.unityLogger.logEnabled = m_enable;
            Debug.unityLogger.filterLogType = m_filter;
        }
    }
}
