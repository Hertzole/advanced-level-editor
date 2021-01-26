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
                else if ((UnityObject)item == null)
                {
                    toggle.Label.text = "None";
                }
            }
        }

        public void Show(Type type, bool sceneObject)
        {
            if (sceneObject)
            {
                List<ILevelEditorObject> allObjects = new List<ILevelEditorObject>(LevelEditor.ObjectManager.GetAllObjects());
                if (type == typeof(GameObject) || type == typeof(Transform)) // All objects are game objects or have a transform.
                {
                    allObjects.Insert(0, null);
                    listView.SetItems(allObjects);
                }
                else
                {
                    List<ILevelEditorObject> typeObjects = new List<ILevelEditorObject>();

                    for (int i = 0; i < allObjects.Count; i++)
                    {
                        if (allObjects[i].MyGameObject.GetComponent(type))
                        {
                            typeObjects.Add(allObjects[i]);
                        }
                    }

                    typeObjects.Insert(0, null);

                    listView.SetItems(typeObjects);
                }
            }

            Show(true);
        }
    }
}
