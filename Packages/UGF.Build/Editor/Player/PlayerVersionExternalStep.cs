using System;
using System.IO;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;
using UnityEngine;

namespace UGF.Build.Editor.Player
{
    public class PlayerVersionExternalStep : BuildStep
    {
        public string Path { get; }
        public bool SetPlayerBundleVersion { get; }

        public PlayerVersionExternalStep(string path, bool setPlayerBundleVersion)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            Path = path;
            SetPlayerBundleVersion = setPlayerBundleVersion;
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            string text = File.ReadAllText(Path);
            var data = JsonUtility.FromJson<PlayerVersionData>(text);

            context.Add(data);

            if (SetPlayerBundleVersion)
            {
                PlayerSettings.bundleVersion = data.Version;
            }
        }
    }
}
