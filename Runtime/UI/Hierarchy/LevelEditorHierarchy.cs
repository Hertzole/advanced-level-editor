using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hertzole.ALE
{
    public class LevelEditorHierarchy : MonoBehaviour
    {
        [SerializeField]
        private HierarchyTree treeControl = null;

        private void Awake()
        {
            treeControl.Initialize(
            (go) =>
            {
                return go.transform.parent == null ? null : go.transform.parent.gameObject;
            },
            (go) =>
            {
                List<GameObject> result = new List<GameObject>();

                for (int i = 0; i < go.transform.childCount; i++)
                {
                    result.Add(go.transform.GetChild(i).gameObject);
                }

                return result;
            });

            treeControl.OnBindItem += OnBindItem;
            treeControl.OnReparent += OnReparentItem;
            treeControl.OnItemExpandingCollapsing += OnItemExpanding;
        }

        // Start is called before the first frame update
        void Start()
        {
            GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            treeControl.AddItems(rootObjects);
        }

        private void OnBindItem(object sender, TreeBindItemEventArgs<HierarchyItem, GameObject> e)
        {
            e.TreeItem.LabelText.text = e.Item.name;
            e.TreeItem.HasChildren = e.Item.transform.childCount > 0;

#if UNITY_EDITOR
            e.TreeItem.gameObject.name = $"Item - {e.Item.name}";
#endif
        }

        private void OnReparentItem(object sender, TreeReparentEventArgs<GameObject> e)
        {
            switch (e.Action)
            {
                case ItemDropAction.SetLastChild:
                    if (e.Target != null)
                    {
                        e.DraggingItem.transform.SetParent(e.Target.transform, true);
                        e.DraggingItem.transform.SetAsLastSibling();
                    }
                    else
                    {
                        e.DraggingItem.transform.SetParent(null, true);
                    }
                    break;
                case ItemDropAction.SetPreviousSibling:
                    if (e.Target != null)
                    {
                        if (e.DraggingItem.transform.parent != e.Target.transform.parent)
                        {
                            e.DraggingItem.transform.SetParent(e.Target.transform.parent, true);
                        }

                        int targetIndex = e.Target.transform.GetSiblingIndex();
                        int currentIndex = e.DraggingItem.transform.GetSiblingIndex();

                        if (targetIndex > currentIndex)
                        {
                            e.DraggingItem.transform.SetSiblingIndex(targetIndex - 1);
                        }
                        else
                        {
                            e.DraggingItem.transform.SetSiblingIndex(targetIndex);
                        }
                    }
                    break;
                case ItemDropAction.SetNextSibling:
                    if (e.Target != null)
                    {
                        int targetIndex = e.Target.transform.GetSiblingIndex();
                        int currentIndex = e.DraggingItem.transform.GetSiblingIndex();

                        if (e.DraggingItem.transform.parent != e.Target.transform.parent)
                        {
                            e.DraggingItem.transform.SetParent(e.Target.transform.parent, true);
                            e.DraggingItem.transform.SetSiblingIndex(targetIndex + 1);
                        }
                        else
                        {
                            if (targetIndex < currentIndex)
                            {
                                e.DraggingItem.transform.SetSiblingIndex(targetIndex + 1);
                            }
                            else
                            {
                                e.DraggingItem.transform.SetSiblingIndex(targetIndex);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void OnItemExpanding(object sender, TreeExpandingEventArgs<GameObject> e)
        {
            if (e.Parent.transform.childCount > 0)
            {
                for (int i = 0; i < e.Parent.transform.childCount; i++)
                {
                    e.Children.Add(e.Parent.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
