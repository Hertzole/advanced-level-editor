using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
	public class LevelEditorSaveModal : MonoBehaviour, ILevelEditorSaveModal
	{
		[SerializeField]
		private TMP_InputField nameField;
		[SerializeField]
		private Button saveButton;
		[SerializeField]
		private Button cancelButton;
		[SerializeField]
		private Button closeButton;

		[Space]
		[SerializeField]
		private bool applyLevelNameOnLoad = true;
		[SerializeField]
		private bool closeOnSave = true;
		[SerializeField]
		private bool askBeforeOverride = true;

		[Space]
		[SerializeField]
		[RequireType(typeof(ILevelEditorSaveManager))]
		private GameObject saveManager;

		public ILevelEditorSaveManager SaveManager { get; set; }

		public bool ApplyLevelNameOnLoad { get { return applyLevelNameOnLoad; } set { applyLevelNameOnLoad = value; } }

		public string LevelName { get { return nameField.text; } set { nameField.text = value; } }

		GameObject ILevelEditorModal.MyGameObject { get { return gameObject; } }

		public event Action<string> OnSave;
		public event Action OnClose;

		private void Awake()
		{
			if (nameField != null)
			{
				nameField.onValueChanged.AddListener(x => ValidateSaveButton());
			}

			if (saveManager != null)
			{
				SaveManager = saveManager.NeedComponent<ILevelEditorSaveManager>();
				SaveManager.OnLevelLoaded += OnLevelLoaded;
			}

			if (saveButton != null)
			{
				saveButton.onClick.AddListener(() =>
				{
					if (SaveManager != null)
					{
						SaveManager.SaveLevel(nameField.text);
					}

					OnSave?.Invoke(nameField.text);
					if (closeOnSave)
					{
						Close();
					}

					//TODO: Ask before override.
					LevelEditorLogger.LogTodo("Ask before override");
				});
			}

			if (cancelButton != null)
			{
				cancelButton.onClick.AddListener(Close);
			}

			if (closeButton != null)
			{
				closeButton.onClick.AddListener(Close);
			}
			
			ValidateSaveButton();
		}

		private void OnDestroy()
		{
			if (SaveManager != null)
			{
				SaveManager.OnLevelLoaded -= OnLevelLoaded;
			}
		}

		private void OnLevelLoaded(object sender, LevelEventArgs e)
		{
			if (applyLevelNameOnLoad)
			{
				nameField.SetTextWithoutNotify(e.Data.name);
			}
		}

		private void ValidateSaveButton()
		{
			if (saveButton != null)
			{
				saveButton.interactable = !string.IsNullOrWhiteSpace(nameField.text);
			}
		}

		public void Close()
		{
			OnClose?.Invoke();
		}
	}
}