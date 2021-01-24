using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
    [AddComponentMenu("ALE/Editor Modes/Unified Mode", 500)]
#endif
    public class UnifiedMode : LevelEditorMode
    {
        [SerializeField, RequireType(typeof(ILevelEditorResourceView))]
        private GameObject resourcePanel = null;

        private ILevelEditorResourceView realResourcePanel;

        private void Awake()
        {
            realResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();
        }

        public override void OnModeEnable()
        {
            realResourcePanel.OnClickAsset += OnClickAsset;
        }

        public override void OnModeDisable()
        {
            realResourcePanel.OnClickAsset -= OnClickAsset;
        }

        private void OnClickAsset(object sender, AssetClickEventArgs e)
        {
            ILevelEditorObject obj = ObjectManager.CreateObject(e.Asset);
            Selection.Selection = obj;
        }
    }
}
