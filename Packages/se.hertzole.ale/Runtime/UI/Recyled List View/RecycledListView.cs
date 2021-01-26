using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [RequireComponent(typeof(ScrollRect))]
    public class RecycledListView : MonoBehaviour
    {
        [SerializeField]
        [HideInInspector]
        private ScrollRect scroll = null;

        private bool isDirty = false;

        private int currentTopIndex = -1;
        private int currentBottomIndex = -1;

        private float itemHeight;
        private float oneOverItemHeight;
        private float viewportWidth;
        private float viewportHeight;

        private readonly Dictionary<int, RecycledListItem> items = new Dictionary<int, RecycledListItem>();
        private readonly Stack<RecycledListItem> pooledItems = new Stack<RecycledListItem>();

        public RectTransform Viewport { get { return scroll.viewport; } }
        public RectTransform Content { get { return scroll.content; } }

        private List<object> itemsSource = new List<object>();

        public int ItemCount { get { return itemsSource.Count; } }

        public Func<RecycledListItem> OnCreateItem;
        public event Action<int, object, RecycledListItem> OnBindItem;

        private void Awake()
        {
            scroll.onValueChanged.AddListener(pos => UpdateItemsInTheList());
        }

        public void Initialize(IEnumerable<object> items, float itemHeight)
        {
            itemsSource.Clear();
            if (items != null)
            {
                itemsSource.AddRange(items);
            }

            this.itemHeight = itemHeight;
            oneOverItemHeight = 1f / itemHeight;

            Canvas.ForceUpdateCanvases();

            UpdateList();
        }

        public void SetItems(IEnumerable<object> items, bool updateList = true)
        {
            itemsSource.Clear();
            itemsSource.AddRange(items);

            if (updateList)
            {
                UpdateList(true);
            }
        }

        public void AddItems(IEnumerable<object> items, bool updateList = true)
        {
            itemsSource.AddRange(items);
            if (updateList)
            {
                UpdateList(false);
            }
        }

        public void AddItem(object item, bool updateList = true)
        {
            itemsSource.Add(item);
            if (updateList)
            {
                UpdateList(false);
            }
        }

        public void RemoveItem(object item, bool updateList = true)
        {
            itemsSource.Remove(item);
            if (updateList)
            {
                UpdateList(false);
            }
        }

        public void MoveItem(object item, int index, bool updateList = true)
        {
            int oldIndex = itemsSource.IndexOf(item);
            itemsSource.Remove(item);
            itemsSource.Insert(oldIndex < index ? index - 1 : index, item);

            if (updateList)
            {
                UpdateList(false);
            }
        }

        public void InsertItem(object item, int index, bool updateList = true)
        {
            itemsSource.Insert(index, item);

            if (updateList)
            {
                UpdateList(false);
            }
        }

        public int IndexOf(object item)
        {
            return itemsSource.IndexOf(item);
        }

        public object GetItem(int index)
        {
            return index < 0 || index >= itemsSource.Count ? null : itemsSource[index];
        }

        public bool HasItem(object item)
        {
            return itemsSource.Contains(item);
        }

        public RecycledListItem GetListItem(int index)
        {
            return items[index];
        }

        private void Update()
        {
            if (isDirty)
            {
                Vector2 viewportSize = Viewport.rect.size;
                viewportWidth = viewportSize.x;
                viewportHeight = viewportSize.y;

                isDirty = false;
                UpdateItemsInTheList();
            }
        }

        public void UpdateList(bool resetContentPosition = true)
        {
            if (resetContentPosition)
            {
                Content.anchoredPosition = Vector2.zero;
            }

            float newHeight = Mathf.Max(1f, itemsSource.Count * itemHeight);
            Content.sizeDelta = new Vector2(Content.sizeDelta.x, newHeight);

            Vector2 viewportSize = Viewport.rect.size;
            viewportWidth = viewportSize.x;
            viewportHeight = viewportSize.y;

            UpdateItemsInTheList(true);
        }

        public void ResetList()
        {
            oneOverItemHeight = 1f / itemHeight;

            if (currentTopIndex > -1 && currentBottomIndex > -1)
            {
                if (currentBottomIndex > itemsSource.Count - 1)
                {
                    currentBottomIndex = itemsSource.Count - 1;
                }

                DestroyItemsBetweenIndicies(currentTopIndex, currentBottomIndex);

                currentTopIndex = -1;
                currentBottomIndex = -1;
            }

            UpdateList();
        }

        private void OnRectTransformDimensionsChange()
        {
            isDirty = true;
        }

        private void UpdateItemsInTheList(bool updateAllVisibleItems = false)
        {
            if (itemsSource.Count > 0)
            {
                float contentPos = Content.anchoredPosition.y - 1f;

                int newTopIndex = (int)(contentPos * oneOverItemHeight);
                int newBottomIndex = (int)((contentPos + viewportHeight + 2f) * oneOverItemHeight);

                if (newTopIndex < 0)
                {
                    newTopIndex = 0;
                }

                if (newBottomIndex > itemsSource.Count - 1)
                {
                    newBottomIndex = itemsSource.Count - 1;
                }

                if (currentTopIndex == -1)
                {
                    // There are no active items.
                    updateAllVisibleItems = true;

                    currentTopIndex = newTopIndex;
                    currentBottomIndex = newBottomIndex;

                    CreateItemsBetweenIndicies(newTopIndex, newBottomIndex);
                }
                else
                {
                    // There are active items.

                    if (newBottomIndex < currentTopIndex || newTopIndex > currentBottomIndex)
                    {
                        updateAllVisibleItems = true;

                        DestroyItemsBetweenIndicies(currentTopIndex, currentBottomIndex);
                        CreateItemsBetweenIndicies(newTopIndex, newBottomIndex);
                    }
                    else
                    {
                        if (newTopIndex > currentTopIndex)
                        {
                            DestroyItemsBetweenIndicies(currentTopIndex, newTopIndex - 1);
                        }

                        if (newBottomIndex < currentBottomIndex)
                        {
                            DestroyItemsBetweenIndicies(newBottomIndex + 1, currentBottomIndex);
                        }

                        if (newTopIndex < currentTopIndex)
                        {
                            CreateItemsBetweenIndicies(newTopIndex, currentTopIndex - 1);

                            if (!updateAllVisibleItems)
                            {
                                UpdateItemContentsBetweenIndicies(newTopIndex, currentTopIndex - 1);
                            }
                        }

                        if (newBottomIndex > currentBottomIndex)
                        {
                            CreateItemsBetweenIndicies(currentBottomIndex + 1, newBottomIndex);

                            if (!updateAllVisibleItems)
                            {
                                UpdateItemContentsBetweenIndicies(currentBottomIndex + 1, newBottomIndex);
                            }
                        }
                    }

                    currentTopIndex = newTopIndex;
                    currentBottomIndex = newBottomIndex;
                }

                if (updateAllVisibleItems)
                {
                    UpdateItemContentsBetweenIndicies(currentTopIndex, currentBottomIndex);
                }
            }
            else if (currentTopIndex != -1)
            {
                DestroyItemsBetweenIndicies(currentTopIndex, currentBottomIndex);

                currentTopIndex = -1;
            }
        }

        private void CreateItemsBetweenIndicies(int topIndex, int bottomIndex)
        {
            for (int i = topIndex; i <= bottomIndex; i++)
            {
                CreateItemAtIndex(i);
            }
        }

        private void CreateItemAtIndex(int index)
        {
            RecycledListItem item;
            if (pooledItems.Count > 0)
            {
                item = pooledItems.Pop();
                item.gameObject.SetActive(true);
            }
            else
            {
                item = OnCreateItem?.Invoke();
                item.transform.SetParent(Content, false);
            }

            ((RectTransform)item.transform).anchoredPosition = new Vector2(0f, -index * itemHeight);

            items[index] = item;
        }

        private void DestroyItemsBetweenIndicies(int topIndex, int bottomIndex)
        {
            for (int i = topIndex; i <= bottomIndex; i++)
            {
                RecycledListItem item = items[i];

                item.gameObject.SetActive(false);
                pooledItems.Push(item);
            }
        }

        private void UpdateItemContentsBetweenIndicies(int topIndex, int bottomIndex)
        {
            for (int i = topIndex; i <= bottomIndex; i++)
            {
                RecycledListItem item = items[i];
                item.Position = i;
                OnBindItem?.Invoke(i, itemsSource[i], item);
            }
        }

        public void BindItem(object item)
        {
            int index = IndexOf(item);
            RecycledListItem listItem = GetListItem(index);
            OnBindItem?.Invoke(index, item, listItem);
        }

        public void ForEachListItem(Action<int, RecycledListItem> action)
        {
            foreach (KeyValuePair<int, RecycledListItem> item in items)
            {
                action.Invoke(item.Key, item.Value);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (scroll == null)
            {
                scroll = GetComponent<ScrollRect>();
            }
        }
#endif
    }
}
