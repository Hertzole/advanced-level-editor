using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
	public class LevelEditorLoadModal : MonoBehaviour, ILevelEditorLoadModal
	{
		[SerializeField]
		private Button closeButton;
		[SerializeField]
		private ListToggle levelToggle;
		[SerializeField]
		private RecycledListView listView;
		[SerializeField]
		private Button loadButton;

		[Space]
		[SerializeField]
		[RequireType(typeof(ILevelEditorSaveManager))]
		private GameObject saveManager;

		private int selectedLevel = -1;

		private string[] levels;

		public ILevelEditorSaveManager SaveManager { get; set; }

		GameObject ILevelEditorModal.MyGameObject { get { return gameObject; } }

		public event Action<string> OnLoadLevel;
		public event Action OnClose;

		private void Awake()
		{
			listView.OnCreateItem = OnCreateListItem;
			listView.OnBindItem += OnBindListItem;

			listView.Initialize(null, ((RectTransform) levelToggle.transform).sizeDelta.y);

			loadButton.onClick.AddListener(ClickLoadLevel);
			closeButton.onClick.AddListener(Close);

			if (saveManager != null)
			{
				SaveManager = saveManager.NeedComponent<ILevelEditorSaveManager>();
			}

			ValidateLoadButton();
		}

		private void OnEnable()
		{
			if (SaveManager != null)
			{
				PopulateLevels(SaveManager.GetLevels());
			}
		}

		private RecycledListItem OnCreateListItem()
		{
			ListToggle toggle = Instantiate(levelToggle);
			toggle.OnToggled += OnLevelToggled;
			return toggle;
		}

		private void OnLevelToggled(int index, bool isOn)
		{
			if (isOn)
			{
				selectedLevel = index;
				ValidateLoadButton();
			}

			listView.ForEachListItem((i, item) =>
			{
				if (item is ListToggle toggle)
				{
					toggle.SetToggledWithoutNotify(i == index);
					toggle.Interactable = i != index;
				}
			});
		}

		private void OnBindListItem(int index, object item, RecycledListItem listItem)
		{
			if (listItem is ListToggle toggle)
			{
				toggle.Index = index;
				toggle.Label.text = Path.GetFileNameWithoutExtension((string) item);
				toggle.SetToggledWithoutNotify(index == selectedLevel);
				toggle.Interactable = index != selectedLevel;
			}
		}

		private void ClickLoadLevel()
		{
			if (SaveManager != null)
			{
				SaveManager.LoadLevel(levels[selectedLevel]);
			}
			
			OnLoadLevel?.Invoke(levels[selectedLevel]);
			OnClose?.Invoke();
		}

		private void ValidateLoadButton()
		{
			loadButton.interactable = selectedLevel >= 0 && selectedLevel < levels.Length;
		}

		public void Close()
		{
			OnClose?.Invoke();
		}

		public void PopulateLevels(string[] paths)
		{
			levels = paths;
			selectedLevel = -1;

			listView.SetItems(paths);
			ValidateLoadButton();
		}
	}
}