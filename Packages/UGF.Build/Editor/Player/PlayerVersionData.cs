using System;
using UnityEngine;

namespace UGF.Build.Editor.Player
{
    [Serializable]
    public class PlayerVersionData
    {
        [SerializeField] private string version;

        public string Version { get { return version; } set { version = value; } }
    }
}
