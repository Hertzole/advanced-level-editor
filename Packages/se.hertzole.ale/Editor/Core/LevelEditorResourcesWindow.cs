using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public class LevelEditorResourcesWindow : EditorWindow
    {
        [SerializeField]
        private TreeViewState treeState;

        private bool initialized;

        private LevelEditorResourceList asset;
        private SearchField searchField;
        private ResourceListTree treeView;

        private Rect MultiColumnTreeViewRect { get { return new Rect(20, 50, position.width - 40, position.height - 60); } }
        private Rect ToolbarRect { get { return new Rect(20f, 10f, position.width - 40f, 20f); } }
        private Rect BottomToolbarRect { get { return new Rect(20f, 30, position.width - 40f, 20f); } }

        private static LevelEditorResourcesWindow GetWindow()
        {
            LevelEditorResourcesWindow window = GetWindow<LevelEditorResourcesWindow>();
            window.Focus();
            window.Repaint();
            window.minSize = new Vector2(600, 400);
            return window;
        }

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            LevelEditorResourceList myAsset = EditorUtility.InstanceIDToObject(instanceID) as LevelEditorResourceList;
            if (myAsset != null)
            {
                OpenAsset(myAsset);
                return true;
            }
            return false;
        }

        public static void OpenAsset(LevelEditorResourceList asset)
        {
            LevelEditorResourcesWindow window = GetWindow();
            window.SetAsset(asset);
        }

        public void SetAsset(LevelEditorResourceList asset)
        {
            this.asset = asset;
            titleContent = new GUIContent(asset == null ? "Resource List" : asset.name);
            initialized = false;
        }

        private void OnDisable()
        {
            if (asset != null)
            {
                EditorUtility.SetDirty(asset);
            }

            initialized = false;
        }

        private void InitializeIfNeeded()
        {
            if (!initialized)
            {
                if (treeState == null)
                {
                    treeState = new TreeViewState();
                }

                TreeModel<LevelEditorResource> treeModel = new TreeModel<LevelEditorResource>(GetData());

                treeView = new ResourceListTree(treeState, treeModel);

                searchField = new SearchField();
                searchField.downOrUpArrowKeyPressed += treeView.SetFocusAndEnsureSelectedItem;

                initialized = true;
            }
        }

        IList<LevelEditorResource> GetData()
        {
            if (asset == null)
            {
                return EmptyTree();
            }

            List<LevelEditorResource> resources = asset.GetResourcesList();

            if (resources != null && resources.Count > 0)
            {
                return resources;
            }

            return EmptyTree();
        }

        private List<LevelEditorResource> EmptyTree()
        {
            List<LevelEditorResource> treeElements = new List<LevelEditorResource>();
            LevelEditorResource root = new LevelEditorResource() { Name = "Root", ID = "ale_tree_view_root", TreeDepth = -1, TreeID = 0 };
            treeElements.Add(root);

            return treeElements;
        }

        private void OnSelectionChange()
        {
            if (!initialized)
            {
                return;
            }

            LevelEditorResourceList myAsset = Selection.activeObject as LevelEditorResourceList;
            if (myAsset != null && myAsset != asset)
            {
                asset = myAsset;
                treeView.TreeModel.SetData(GetData());
                treeView.Reload();
            }
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            InitializeIfNeeded();

            SearchBar(ToolbarRect);
            BottomToolbar(BottomToolbarRect);
            DoTreeView(MultiColumnTreeViewRect);

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(asset);
            }
        }

        private void SearchBar(Rect rect)
        {
            if (treeView != null && searchField != null)
            {
                treeView.searchString = searchField.OnGUI(rect, treeView.searchString);
            }
        }

        private void DoTreeView(Rect rect)
        {
            if (treeView != null)
            {
                treeView.OnGUI(rect);
            }
        }

        void BottomToolbar(Rect rect)
        {
            GUILayout.BeginArea(rect);

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Expand All"))
                {
                    treeView.ExpandAll();
                }

                if (GUILayout.Button("Collapse All"))
                {
                    treeView.CollapseAll();
                }

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Add Item to Root"))
                {
                    treeView.AddItemToRoot();
                }
            }

            GUILayout.EndArea();
        }
    }
}
