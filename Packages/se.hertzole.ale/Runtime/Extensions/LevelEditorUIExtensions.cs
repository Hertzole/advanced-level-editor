namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		public static void ToggleInspectorPanel(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleInspectorPanel(toggle, false);
		}
		
		public static void ToggleResourcePanel(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleResourcePanel(toggle, false);
		}
		
		public static void ToggleHierarchyPanel(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleHierarchyPanel(toggle, false);
		}
		
		public static void ToggleSaveModal(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleSaveModal(toggle, false);
		}
		
		public static void ToggleLoadModal(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleLoadModal(toggle, false);
		}
		
		public static void ToggleMessageModal(this ILevelEditorUI ui, bool toggle)
		{
			ui.ToggleMessageModal(toggle, false);
		}
	}
}