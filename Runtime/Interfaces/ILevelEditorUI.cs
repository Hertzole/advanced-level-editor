namespace Hertzole.ALE
{
	public interface ILevelEditorUI : ILevelEditorPlayModeObject
	{
		ILevelEditor LevelEditor { get; }
		
		ILevelEditorInspector InspectorPanel { get; }
		ILevelEditorResourceView ResourcePanel { get; }
		ILevelEditorHierarchy HierarchyPanel { get; }
		
		ILevelEditorSaveModal SaveModal { get; }
		ILevelEditorLoadModal LoadModal { get; }
		ILevelEditorMessageModal MessageModal { get; }

		ILevelEditorColorPickerWindow ColorPickerWindow { get; }
		ILevelEditorObjectPickerWindow ObjectPickerWindow { get; }

		void ToggleInspectorPanel(bool toggle, bool instant);
		void ToggleResourcePanel(bool toggle, bool instant);
		void ToggleHierarchyPanel(bool toggle, bool instant);

		void ToggleSaveModal(bool toggle, bool instant);
		void ToggleLoadModal(bool toggle, bool instant);
		void ToggleMessageModal(bool toggle, bool instant);
	}
}