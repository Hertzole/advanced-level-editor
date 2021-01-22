using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorResourceView : MonoBehaviour, ILevelEditorResourceView
    {
        [SerializeField]
        private ObjectTree folderTree = null;
        [SerializeField]
        private bool showRoot = false;
        [SerializeField]
        private string rootName = "Assets";

        protected LevelEditorResource treeRoot;
        protected LevelEditorResource[] allAssets;

        public event Action<string> OnClickAsset;
        public event Action<int> OnClickFolder;

        private void Awake()
        {
            folderTree.OnBindItem += OnBindTreeItem;
            folderTree.OnItemExpandingCollapsing += OnTreeItemExpandCollapsing;
        }

        private void OnBindTreeItem(object sender, TreeBindItemEventArgs<TreeItem, object> e)
        {
            if (e.Item is LevelEditorResource resource)
            {
                e.TreeItem.LabelText.text = resource.Name;
                e.TreeItem.HasChildren = resource.HasChildren();
            }
        }

        private void OnTreeItemExpandCollapsing(object sender, TreeExpandingEventArgs<object> e)
        {
            if (e.Parent is LevelEditorResource resource && resource.HasChildren())
            {
                for (int i = 0; i < resource.Children.Count; i++)
                {
                    e.Children.Add(resource.Children[i]);
                }
            }
        }

        public void Initialize(ILevelEditorResource[] resources)
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (!(resources is LevelEditorResource[]))
            {
                throw new NotSupportedException("LevelEditorProjectView only works with LevelEditorResource classes.");
            }
#endif

#if UNITY_EDITOR // This needs to be done to avoid a problem with opening up the resources object in the editor.
            LevelEditorResource[] newResources = new LevelEditorResource[resources.Length];
            for (int i = 0; i < newResources.Length; i++)
            {
                newResources[i] = new LevelEditorResource(resources[i] as LevelEditorResource);
            }
#else
            LevelEditorResource[] newResources = resources as LevelEditorResource[];
#endif

            // Need to create a copy here or else the children will not work in the asset view.
            LevelEditorResource[] resourcesCopy = new LevelEditorResource[newResources.Length];
            for (int i = 0; i < resources.Length; i++)
            {
                resourcesCopy[i] = new LevelEditorResource(newResources[i]);
            }

            allAssets = TreeUtility.AssignChildren(newResources);
            treeRoot = TreeUtility.ListToTree(resourcesCopy, true);
            treeRoot.Name = rootName;

            folderTree.Initialize((child) =>
            {
                return ((LevelEditorResource)child).Parent;
            }, (parent) =>
            {
                List<object> children = new List<object>();
                children.AddRange(((LevelEditorResource)parent).Children);

                return children;
            });

            if (showRoot)
            {
                folderTree.SetItems(new LevelEditorResource[1] { treeRoot });
            }
            else
            {
                for (int i = 0; i < treeRoot.Children.Count; i++)
                {
                    treeRoot.Children[i].Parent = null; // Remove children so they don't get indented.
                }
                folderTree.SetItems(treeRoot.Children);

            }
        }
    }
}
