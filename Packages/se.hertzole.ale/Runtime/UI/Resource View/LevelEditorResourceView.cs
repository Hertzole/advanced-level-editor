using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE
{
    public class LevelEditorResourceView : MonoBehaviour, ILevelEditorResourceView
    {
        public enum IconHandling { Temporary = 0, SaveInMemory = 1 }
        public enum WaitMethod { EndOfFrame = 0, NextFrame = 1, NextFixedUpdate = 2 }

        [Header("Folders")]
        [SerializeField]
        private ObjectTree folderTree = null;
        [SerializeField]
        private bool showRoot = false;
        [SerializeField]
        private string rootName = "Assets";

        [Header("Assets")]
        [SerializeField]
        private RectTransform assetsContent = null;
        [SerializeField]
        private LevelEditorAssetButton assetButtonPrefab = null;
        [SerializeField]
        private bool displayFirstSpriteAsIcon = true;

        [Header("Icon Handling")]
        [SerializeField]
        private IconHandling iconHandling = IconHandling.SaveInMemory;
        [SerializeField]
        private bool generateAsync = false;
        [SerializeField]
        private WaitMethod asyncWaitMethod = WaitMethod.EndOfFrame;

        private bool creatingIcons;

        protected LevelEditorResource treeRoot;
        protected LevelEditorResource[] allAssets;

        private Coroutine createIconsRoutine;
        private YieldInstruction waitMethod;

        private Dictionary<int, LevelEditorResource> treeLookup = new Dictionary<int, LevelEditorResource>();
        private Dictionary<string, Sprite> iconCache;

        private List<LevelEditorAssetButton> activeButtons = new List<LevelEditorAssetButton>();
        private Stack<LevelEditorAssetButton> pooledAssetButtons = new Stack<LevelEditorAssetButton>();


        public event EventHandler<AssetClickEventArgs> OnClickAsset;
        public event EventHandler<AssetClickEventArgs> OnClickFolder;

        private void Awake()
        {
            folderTree.OnBindItem += OnBindTreeItem;
            folderTree.OnItemExpandingCollapsing += OnTreeItemExpandCollapsing;
            folderTree.OnSelectionChanged += OnTreeSelectionChanged;

            RuntimePreviewGenerator.OrthographicMode = true;
            RuntimePreviewGenerator.BackgroundColor = Color.clear;
            RuntimePreviewGenerator.MarkTextureNonReadable = true;

            if (iconHandling == IconHandling.SaveInMemory)
            {
                iconCache = new Dictionary<string, Sprite>();
            }

            switch (asyncWaitMethod)
            {
                case WaitMethod.EndOfFrame:
                    waitMethod = new WaitForEndOfFrame();
                    break;
                case WaitMethod.NextFrame:
                    waitMethod = null;
                    break;
                case WaitMethod.NextFixedUpdate:
                    waitMethod = new WaitForFixedUpdate();
                    break;
                default:
                    break;
            }
        }

        private void OnBindTreeItem(object sender, TreeBindItemEventArgs<TreeItem, object> e)
        {
            if (e.Item is LevelEditorResource resource)
            {
                e.TreeItem.LabelText.text = resource.Name;
                e.TreeItem.HasChildren = resource.HasChildren();

#if UNITY_EDITOR
                e.TreeItem.gameObject.name = $"Item - {resource.Name}";
#endif
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

        private void OnTreeSelectionChanged(object sender, TreeSelectionArgs<object> e)
        {
            if (e.New is LevelEditorResource resource)
            {
                if (generateAsync && creatingIcons)
                {
                    StopCoroutine(createIconsRoutine);
                }

                creatingIcons = false;
                resource = LookupAsset(resource.TreeID);

                if (activeButtons.Count < resource.Children.Count)
                {
                    for (int i = activeButtons.Count; i < resource.Children.Count; i++)
                    {
                        GetAssetButton();
                    }
                }
                else if (activeButtons.Count > resource.Children.Count)
                {
                    for (int i = activeButtons.Count - 1; i >= resource.Children.Count; i--)
                    {
                        PoolAssetButton(activeButtons[i]);
                    }
                }

                Assert.AreEqual(activeButtons.Count, resource.Children.Count);
                for (int i = 0; i < resource.Children.Count; i++)
                {
                    activeButtons[i].Item = resource.Children[i];
                    activeButtons[i].Label.text = resource.Children[i].Name;
#if UNITY_EDITOR
                    activeButtons[i].gameObject.name = $"{assetButtonPrefab.name} - {resource.Children[i].Name} ({resource.Children[i].ID})";
#endif

                    if (generateAsync)
                    {
                        activeButtons[i].Icon.sprite = null;
                        activeButtons[i].Icon.color = Color.clear;
                    }
                    else
                    {
                        activeButtons[i].Icon.sprite = GetIcon(resource.Children[i], out Color iconColor);
                        activeButtons[i].Icon.color = iconColor;
                    }
                }

                if (generateAsync)
                {
                    createIconsRoutine = StartCoroutine(GetIconsRoutine(resource.Children));
                }
            }
            else if (e.New == null)
            {
                for (int i = activeButtons.Count - 1; i >= 0; i--)
                {
                    PoolAssetButton(activeButtons[i]);
                }
            }
        }

        private IEnumerator GetIconsRoutine(List<LevelEditorResource> resources)
        {
            creatingIcons = true;

            for (int i = 0; i < resources.Count; i++)
            {
                activeButtons[i].Icon.sprite = GetIcon(resources[i], out Color iconColor, out bool isCached);
                activeButtons[i].Icon.color = iconColor;

                if (!isCached)
                {
                    yield return waitMethod;
                }
            }

            creatingIcons = false;
        }

        private Sprite GetIcon(ILevelEditorResource resource, out Color color)
        {
            return GetIcon(resource, out color, out _);
        }

        private Sprite GetIcon(ILevelEditorResource resource, out Color color, out bool isCached)
        {
            isCached = false;
            if (resource.CustomIcon && resource.Icon != null)
            {
                color = Color.white;
                return resource.Icon;
            }
            else if (iconHandling == IconHandling.SaveInMemory && iconCache.TryGetValue(resource.ID, out Sprite cachedIcon))
            {
                color = Color.white;
                isCached = true;
                return cachedIcon;
            }
            else
            {
                if (resource.Asset is GameObject go)
                {
                    if (displayFirstSpriteAsIcon)
                    {
                        SpriteRenderer goSprite = go.GetComponentInChildren<SpriteRenderer>();
                        if (goSprite != null)
                        {
                            color = goSprite.color;
                            return goSprite.sprite;
                        }
                    }
                    Texture2D icon = RuntimePreviewGenerator.GenerateModelPreview(go.transform, 128, 128, true);
                    Sprite spriteIcon = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), new Vector2(0.5f, 0.5f));

                    if (iconHandling == IconHandling.SaveInMemory)
                    {
                        iconCache.Add(resource.ID, spriteIcon);
                    }

                    color = Color.white;
                    return spriteIcon;
                }
            }

            color = Color.clear;
            return null;
        }

        private void OnClickAssetButton(object sender, AssetButtonClickArgs args)
        {
            if (args.Item is LevelEditorResource resource)
            {
                if (resource.HasChildren())
                {
                    OnClickFolder?.Invoke(this, new AssetClickEventArgs(resource, true));
                }
                else
                {
                    OnClickAsset?.Invoke(this, new AssetClickEventArgs(resource, false));
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
                folderTree.SelectItem(treeRoot);
            }
            else
            {
                for (int i = 0; i < treeRoot.Children.Count; i++)
                {
                    treeRoot.Children[i].Parent = null; // Remove parent so they don't get indented.
                }
                folderTree.SetItems(treeRoot.Children);
                folderTree.SelectItem(treeRoot.Children[0]);
            }
        }

        private LevelEditorAssetButton GetAssetButton()
        {
            LevelEditorAssetButton button;

            if (pooledAssetButtons.Count > 0)
            {
                button = pooledAssetButtons.Pop();
            }
            else
            {
                button = Instantiate(assetButtonPrefab, assetsContent);
                button.OnClick += OnClickAssetButton;
            }

            button.transform.SetAsLastSibling();
            button.gameObject.SetActive(true);
            activeButtons.Add(button);

            return button;
        }

        private void PoolAssetButton(LevelEditorAssetButton assetButton)
        {
            activeButtons.Remove(assetButton);
            pooledAssetButtons.Push(assetButton);
            assetButton.gameObject.SetActive(false);
        }

        private LevelEditorResource LookupAsset(int treeID)
        {
            if (!treeLookup.TryGetValue(treeID, out LevelEditorResource asset))
            {
                for (int i = 0; i < allAssets.Length; i++)
                {
                    if (allAssets[i].TreeID == treeID)
                    {
                        asset = allAssets[i];
                        treeLookup.Add(asset.TreeID, asset);
                        break;
                    }
                }
            }

            return asset;
        }
    }
}
