using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGF.Build.Editor.Player
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Build/Player Scenes Step", order = 2000)]
    public class PlayerScenesStepAsset : BuildStepAsset
    {
        [AssetId(typeof(Scene))]
        [SerializeField] private List<GlobalId> m_scenes = new List<GlobalId>();

        public List<GlobalId> Scenes { get { return m_scenes; } }

        protected override IBuildStep OnBuild()
        {
            return new PlayerScenesStep(m_scenes);
        }
    }
}
