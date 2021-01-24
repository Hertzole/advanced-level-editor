using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorLoadModal : MonoBehaviour, ILevelEditorLoadModal
    {
        [SerializeField]
        private Button closeButton = null;
        [SerializeField]
        private LevelToggle levelToggle = null;
        [SerializeField]
        private RecycledListView listView = null;
        [SerializeField]
        private Button loadButton = null;

        private int selectedLevel = -1;

        private string[] levels;

        public event Action<string> OnClickLoadLevel;
        public event Action OnClickClose;

        GameObject ILevelEditorLoadModal.MyGameObject { get { return gameObject; } }

        public void Initialize()
        {
            listView.OnCreateItem = OnCreateListItem;
            listView.OnBindItem += OnBindListItem;

            listView.Initialize(null, ((RectTransform)levelToggle.transform).sizeDelta.y);

            loadButton.onClick.AddListener(ClickLoadLevel);
            closeButton.onClick.AddListener(Close);

            ValidateLoadButton();
        }

        private RecycledListItem OnCreateListItem()
        {
            LevelToggle toggle = Instantiate(levelToggle);
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
                if (item is LevelToggle toggle)
                {
                    toggle.SetToggledWithoutNotify(i == index);
                    toggle.Interactable = i != index;
                }
            });
        }

        private void OnBindListItem(int index, object item, RecycledListItem listItem)
        {
            if (listItem is LevelToggle toggle)
            {
                toggle.Index = index;
                toggle.Label.text = Path.GetFileNameWithoutExtension((string)item);
                toggle.SetToggledWithoutNotify(index == selectedLevel);
                toggle.Interactable = index != selectedLevel;
            }
        }

        private void ClickLoadLevel()
        {
            OnClickLoadLevel?.Invoke(levels[selectedLevel]);
            OnClickClose?.Invoke();
        }

        public void Close()
        {
            OnClickClose?.Invoke();
        }

        public void PopulateLevels(string[] paths)
        {
            levels = paths;
            selectedLevel = -1;

            listView.SetItems(paths);
            ValidateLoadButton();
        }

        private void ValidateLoadButton()
        {
            loadButton.interactable = selectedLevel >= 0 && selectedLevel < levels.Length;
        }
    }
}
