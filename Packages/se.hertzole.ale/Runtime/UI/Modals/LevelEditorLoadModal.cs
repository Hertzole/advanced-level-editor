using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorLoadModal : MonoBehaviour, ILevelEditorLoadModal
    {
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

            loadButton.onClick.AddListener(ClickLoadLevel);
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
                toggle.Label.text = (string)item;
                toggle.SetToggledWithoutNotify(index == selectedLevel);
                toggle.Interactable = index != selectedLevel;
            }
        }

        private void ClickLoadLevel()
        {
            OnClickLoadLevel?.Invoke(levels[selectedLevel]);
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
