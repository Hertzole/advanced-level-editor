using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorMode : MonoBehaviour, ILevelEditorMode
    {
        public ILevelEditor LevelEditor { get; set; }
        public ILevelEditorInput Input { get { return LevelEditor.Input; } }
        public ILevelEditorUI UI { get { return LevelEditor.UI; } }
        public ILevelEditorObjectManager ObjectManager { get { return LevelEditor.ObjectManager; } }
        public ILevelEditorSelection Selection { get { return LevelEditor.Selection; } }

        public virtual void OnModeDisable() { }

        public virtual void OnModeEnable() { }

        public virtual void OnModeUpdate() { }
    }
}
