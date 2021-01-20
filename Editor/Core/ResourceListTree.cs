using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public enum ResourcesColumns { Icon, Name, Object, ID, Limit, GameIcon, TreeID }
    public enum ResourcesSortOption { Name, Object, ID, Limit, GameIcon, TreeID }

    public class ResourceListTree : MultiColumnTreeView<LevelEditorResource, ResourcesSortOption, ResourcesColumns>
    {
        protected override ResourcesSortOption[] SortOptions { get; } =
      {
            ResourcesSortOption.Name,
            ResourcesSortOption.ID,
            ResourcesSortOption.Object,
            ResourcesSortOption.Limit,
            ResourcesSortOption.GameIcon,
            ResourcesSortOption.TreeID,
            ResourcesSortOption.Name,
        };

        private static Texture2D m_FolderIcon = EditorGUIUtility.FindTexture("Folder Icon");
        private static Texture2D m_GameObjectIcon = EditorGUIUtility.FindTexture("UnityEngine/GameObject Icon");
        private static Texture2D m_PrefabIcon = EditorGUIUtility.FindTexture("Prefab Icon");
        private static Texture2D m_AudioIcon = EditorGUIUtility.FindTexture("UnityEngine/AudioSource Icon");
        private static Texture2D m_MaterialIcon = EditorGUIUtility.FindTexture("UnityEngine/Material Icon");
        private static Texture2D m_TextureIcon = EditorGUIUtility.FindTexture("UnityEngine/Texture Icon");
        private static Texture2D m_SpriteIcon = EditorGUIUtility.FindTexture("UnityEngine/Sprite Icon");
        private static Texture2D m_PhysicMaterialIcon = EditorGUIUtility.FindTexture("UnityEngine/PhysicMaterial Icon");
        private static Texture2D m_ScriptableObjectIcon = EditorGUIUtility.FindTexture("UnityEngine/ScriptableObject Icon");

        public ResourceListTree(TreeViewState state, TreeModel<LevelEditorResource> model) : base(state, model) { }

        protected override LevelEditorResource GetNewItem()
        {
            return new LevelEditorResource() { Name = "New Item", ID = "new_item", Hidden = false, Limit = 0 };
        }

        protected override void ContextClickedItem(int id)
        {
            // create the menu and add items to it
            GenericMenu menu = new GenericMenu();

            IList<int> selection = GetSelection();

            if (selection.Count == 1)
            {
                menu.AddItem(new GUIContent("Add Item"), false, AddItemToSelection);
                menu.AddItem(new GUIContent("Remove Item"), false, OnClickedRemoveItem);
                menu.AddItem(new GUIContent("Rename Item"), false, OnClickedRename, id);
            }
            else if (selection.Count > 1)
            {
                menu.AddItem(new GUIContent("Remove Items"), false, OnClickedRemoveItem);
            }

            // display the menu
            menu.ShowAsContext();
        }

        private void OnClickedRemoveItem()
        {
            IList<int> selection = GetSelection();
            if (selection.Count <= 1)
            {
                bool hasChildren = TreeModel.Find(selection[0]).HasChildren();
                if (!hasChildren)
                {
                    TreeModel.RemoveElements(selection);
                }
                else
                {
                    if (EditorUtility.DisplayDialog("Confirmation", "Are you sure you want to remove this element? All of its children objects will also be removed!", "Yes", "No"))
                    {
                        TreeModel.RemoveElements(selection);
                    }
                }
            }
            else
            {
                if (EditorUtility.DisplayDialog("Confirmation", "Are you sure you want to remove all these elements?", "Yes", "No"))
                {
                    TreeModel.RemoveElements(selection);
                }
            }
        }

        private void OnClickedRename(object id)
        {
            BeginRename(FindItem((int)id, rootItem));
        }

        protected override void CellGUI(Rect cellRect, TreeViewItem<LevelEditorResource> item, ResourcesColumns column, ref RowGUIArgs args)
        {
            CenterRectUsingSingleLineHeight(ref cellRect);
            bool isFolder = item.Data.HasChildren();

            if (isFolder)
            {
                item.Data.ID = string.Empty;
            }

            switch (column)
            {
                case ResourcesColumns.Icon:
                    GUI.DrawTexture(cellRect, GetIcon(item), ScaleMode.ScaleToFit);
                    break;
                case ResourcesColumns.Name:
                    CellLabelGUI(cellRect, args);
                    break;
                case ResourcesColumns.Object:
                    if (!isFolder)
                    {
                        item.Data.Asset = EditorGUI.ObjectField(cellRect, GUIContent.none, item.Data.Asset, typeof(UnityEngine.Object), false);
                    }
                    break;
                case ResourcesColumns.ID:
                    if (!isFolder)
                    {
                        item.Data.ID = EditorGUI.TextField(cellRect, GUIContent.none, item.Data.ID);
                    }
                    break;
                case ResourcesColumns.Limit:
                    if (!isFolder)
                    {
                        if (item.Data.Asset != null && item.Data.Asset.GetType() == typeof(GameObject))
                        {
                            item.Data.Limit = EditorGUI.IntField(cellRect, GUIContent.none, item.Data.Limit);
                        }
                    }
                    break;
                case ResourcesColumns.GameIcon:
                    item.Data.CustomIcon = EditorGUI.Toggle(new Rect(cellRect.x, cellRect.y, cellRect.height, cellRect.height), item.Data.CustomIcon);
                    bool oldEnable = GUI.enabled;
                    GUI.enabled = item.Data.CustomIcon;
                    item.Data.Icon = (Sprite)EditorGUI.ObjectField(new Rect(cellRect.x + cellRect.height, cellRect.y, cellRect.width - cellRect.height, cellRect.height), item.Data.Icon, typeof(Sprite), false);
                    GUI.enabled = oldEnable;
                    break;
                case ResourcesColumns.TreeID:
                    if (!isFolder)
                    {
                        oldEnable = GUI.enabled;
                        GUI.enabled = false;
                        EditorGUI.IntField(cellRect, GUIContent.none, item.Data.TreeID);
                        GUI.enabled = oldEnable;
                    }
                    break;
                default:
                    break;
            }
        }

        protected override MultiColumnHeaderState.Column[] CreateColumns()
        {
            return new[]
            {
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent(EditorGUIUtility.FindTexture("FilterByType")),
                    contextMenuText = "Type icon",
                    headerTextAlignment = TextAlignment.Center,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Right,
                    allowToggleVisibility = true,
                    autoResize = false,
                    width = 30,
                    minWidth = 30,
                    maxWidth = 30
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("Name"),
                    contextMenuText = "Name",
                    headerTextAlignment = TextAlignment.Left,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 150,
                    minWidth = 60,
                    autoResize = true,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("Object"),
                    contextMenuText = "Object",
                    headerTextAlignment = TextAlignment.Right,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 150,
                    minWidth = 60,
                    autoResize = false,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("ID"),
                    contextMenuText = "ID",
                    headerTextAlignment = TextAlignment.Right,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 100,
                    minWidth = 40,
                    autoResize = false,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("Limit"),
                    contextMenuText = "Limit",
                    headerTextAlignment = TextAlignment.Right,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 100,
                    minWidth = 40,
                    autoResize = false,
                    allowToggleVisibility = true
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("Icon"),
                    contextMenuText = "Icon",
                    headerTextAlignment = TextAlignment.Right,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 150,
                    minWidth = 60,
                    autoResize = true,
                    allowToggleVisibility = true
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("Tree ID"),
                    contextMenuText = "Tree ID",
                    headerTextAlignment = TextAlignment.Right,
                    sortedAscending = true,
                    sortingArrowAlignment = TextAlignment.Center,
                    width = 150,
                    minWidth = 60,
                    autoResize = true,
                    allowToggleVisibility = true
                }
            };
        }

        protected override IOrderedEnumerable<TreeViewItem<LevelEditorResource>> Sort(ResourcesSortOption sortOption, IEnumerable<TreeViewItem<LevelEditorResource>> items, bool ascending)
        {
            switch (sortOption)
            {
                case ResourcesSortOption.Object:
                    return items.Order(l => l.Data.Asset, ascending);
                case ResourcesSortOption.ID:
                    return items.Order(l => l.Data.ID, ascending);
                case ResourcesSortOption.TreeID:
                    return items.Order(l => l.Data.TreeID, ascending);
                default:
                    return items.Order(l => l.Data.Name, ascending);
            }
        }

        private Texture2D GetIcon(TreeViewItem<LevelEditorResource> item)
        {
            if (item.Data.HasChildren())
            {
                return m_FolderIcon;
            }

            if (item.Data.Asset != null)
            {
                Type objType = item.Data.Asset.GetType();

                if (objType == typeof(GameObject))
                {
                    return m_PrefabIcon;
                }
                else if (objType == typeof(AudioClip))
                {
                    return m_AudioIcon;
                }
                else if (objType == typeof(Material))
                {
                    return m_MaterialIcon;
                }
                else if (objType == typeof(Texture) || objType == typeof(Texture2D))
                {
                    return m_TextureIcon;
                }
                else if (objType == typeof(Sprite))
                {
                    return m_SpriteIcon;
                }
                else if (objType == typeof(PhysicMaterial))
                {
                    return m_PhysicMaterialIcon;
                }
                else if (objType.IsSubclassOf(typeof(ScriptableObject)))
                {
                    return m_ScriptableObjectIcon;
                }
            }

            return m_GameObjectIcon;
        }
    }
}
