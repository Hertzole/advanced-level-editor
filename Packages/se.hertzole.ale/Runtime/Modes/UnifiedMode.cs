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
        [SerializeField, RequireType(typeof(ILevelEditorObjectManager))]
        private GameObject objectManager = null;

        private ILevelEditorResourceView realResourcePanel;
        private ILevelEditorObjectManager realObjectManager;

        private void Awake()
        {
            realResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();
            realObjectManager = objectManager.NeedComponent<ILevelEditorObjectManager>();
        }

        public override void OnModeEnable()
        {
            //realResourcePanel.OnClickAsset += OnProjectViewClickAsset;
        }

        public override void OnModeDisable()
        {
            //realResourcePanel.OnClickAsset -= OnProjectViewClickAsset;
        }

        private void OnProjectViewClickAsset(string id)
        {
            ILevelEditorObject newObj = realObjectManager.CreateObject(id);
            Selection.Selection = newObj;
        }
    }
}
