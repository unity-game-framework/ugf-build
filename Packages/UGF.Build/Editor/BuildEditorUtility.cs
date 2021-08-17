using System;
using UnityEditor;

namespace UGF.Build.Editor
{
    public static class BuildEditorUtility
    {
        public static void Build(BuildTarget buildTarget, string profileName)
        {
            if (string.IsNullOrEmpty(profileName)) throw new ArgumentException("Value cannot be null or empty.", nameof(profileName));
        }
    }
}
