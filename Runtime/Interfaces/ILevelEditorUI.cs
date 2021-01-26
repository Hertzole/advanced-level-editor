using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorUI
    {
        ILevelEditorSaveModal SaveModal { get; }
        ILevelEditorLoadModal LoadModal { get; }
        ILevelEditorInspector InspectorPanel { get; }
        ILevelEditorResourceView ResourcePanel { get; }
        ILevelEditorHierarchy HierarchyPanel { get; }

        ILevelEditorColorPickerWindow ColorPickerWindow { get; }
        ILevelEditorObjectPickerWindow ObjectPickerWindow { get; }

        void Initialize(ILevelEditor levelEditor);

        void InitializeResources(ILevelEditorResource[] resources);

        void ToggleSaveModal(bool toggle);

        void ToggleLoadModal(bool toggle);

        void ToggleResourcePanel(bool toggle);

        void ToggleInspectorPanel(bool toggle);

        void ShowNotification(string title, string text, string yesButton, string noButton, Action onClickYes, Action onClickNo);

        void CloseNotification();

        void OnPlayModeStart();

        void OnPlayModeStop();
    }
}
