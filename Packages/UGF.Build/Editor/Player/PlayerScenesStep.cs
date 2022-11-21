using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor.Player
{
    public class PlayerScenesStep : BuildStep
    {
        public IReadOnlyList<GlobalId> SceneIds { get; }

        public PlayerScenesStep(IReadOnlyList<GlobalId> sceneIds)
        {
            SceneIds = sceneIds ?? throw new ArgumentNullException(nameof(sceneIds));
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            var scenes = new EditorBuildSettingsScene[SceneIds.Count];

            for (int i = 0; i < SceneIds.Count; i++)
            {
                GlobalId sceneId = SceneIds[i];
                string path = AssetDatabase.GUIDToAssetPath(sceneId.ToString());

                scenes[i] = new EditorBuildSettingsScene(path, true);
            }

            EditorBuildSettings.scenes = scenes;
        }
    }
}
