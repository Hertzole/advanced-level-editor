using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorSaveModal : MonoBehaviour, ILevelEditorSaveModal
    {
        [SerializeField]
        private TMP_InputField nameField = null;
        [SerializeField]
        private Button saveButton = null;
        [SerializeField]
        private Button closeButton = null;

        public string LevelName { get { return nameField.text; } }

        public event Action<string> OnClickSave;
        public event Action OnClickClose;

        GameObject ILevelEditorSaveModal.MyGameObject { get { return gameObject; } }

        public void Initialize()
        {
            nameField.onValueChanged.AddListener(x => ValidateSaveButton());
            saveButton.onClick.AddListener(() =>
            {
                OnClickSave?.Invoke(nameField.text);
                Close();
            });
            closeButton.onClick.AddListener(Close);
        }

        private void ValidateSaveButton()
        {
            saveButton.interactable = !string.IsNullOrWhiteSpace(nameField.text);
        }

        public void Close()
        {
            OnClickClose?.Invoke();
        }
    }
}
