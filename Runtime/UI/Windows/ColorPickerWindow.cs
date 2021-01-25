using UnityEngine;

namespace Hertzole.ALE
{
    public class ColorPickerWindow : LevelEditorWindow, ILevelEditorColorPickerWindow
    {
        [SerializeField]
        private ColorPicker colorPicker = null;

        public ColorPicker ColorPicker { get { return colorPicker; } }
    }
}
