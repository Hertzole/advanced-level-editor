using System;
using System.Collections.Generic;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Hertzole.ALE
{
    public class ObjectPickerWindow : LevelEditorWindow, ILevelEditorObjectPickerWindow
    {
        [SerializeField]
        private RecycledListView listView = null;
        [SerializeField]
        private ListToggle listItemPrefab = null;

        public event Action<UnityObject> OnObjectSelected;

        protected override void OnInitialized()
        {
            listView.Initialize(null, ((RectTransform)listItemPrefab.transform).sizeDelta.y);
            listView.OnBindItem += OnBindListItem;
            listView.OnCreateItem = OnCreateListItem;
        }

        private RecycledListItem OnCreateListItem()
        {
            ListToggle result = Instantiate(listItemPrefab, listView.Content);
            result.OnToggled += OnItemToggled;
            return result;
        }

        private void OnItemToggled(int index, bool isOn)
        {
            if (isOn)
            {
                UnityObject item = (UnityObject)listView.GetItem(index);
                if (item == null)
                {
                    OnObjectSelected?.Invoke(null);
                }
                else
                {
                    OnObjectSelected?.Invoke(item);
                }

                Dismiss();
            }
        }

        private void OnBindListItem(int index, object item, RecycledListItem listItem)
        {
            if (listItem is ListToggle toggle)
            {
                toggle.Index = index;
                toggle.SetToggledWithoutNotify(false);
                toggle.Interactable = true;

                if (item is UnityObject obj)
                {
                    toggle.Label.text = obj.name;
                }
                else
                {
                    toggle.Label.text = "None";
                }
            }
        }

        public void Show(Type type, bool sceneObject)
        {
            if (sceneObject)
            {
                List<UnityObject> allObjects = new List<UnityObject>(LevelEditorWorld.GetObjects(type));
                allObjects.Insert(0, null);

                listView.SetItems(allObjects);
            }

            Show(true);
        }
    }
}
