using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public class LevelEditorHierarchy : MonoBehaviour, ILevelEditorHierarchy
	{
		[SerializeField]
		[RequireType(typeof(ILevelEditor))]
		private GameObject levelEditor;

		[Space]
		[SerializeField]
		private HierarchyTree treeControl;
		private bool loadingLevel;
		private bool selectedThroughObjectManager;

		private bool selectedThroughUI;

		protected ILevelEditor realLevelEditor;

		public HierarchyTree TreeControl { get { return treeControl; } set { treeControl = value; } }

		public ILevelEditor LevelEditor
		{
			get { return realLevelEditor; }
			set
			{
				if (realLevelEditor != value)
				{
					SetLevelEditor(value);
				}
			}
		}

		GameObject ILevelEditorPanel.MyGameObject { get { return gameObject; } }

		private void Awake()
		{
			treeControl.Initialize(
				go => { return go == null || go.Parent == null ? null : go.Parent; },
				go =>
				{
					List<ILevelEditorObject> result = new List<ILevelEditorObject>();

					if (go.HasChildren())
					{
						for (int i = 0; i < go.Children.Count; i++)
						{
							result.Add(go.Children[i]);
						}
					}

					return result;
				});

			treeControl.OnBindItem += OnBindItem;
			treeControl.OnReparent += OnReparentItem;
			treeControl.OnItemExpandingCollapsing += OnItemExpanding;
			treeControl.OnSelectionChanged += OnTreeSelectionChanged;

			if (levelEditor != null)
			{
				SetLevelEditor(levelEditor.NeedComponent<ILevelEditor>());
			}
		}

		protected virtual void SetLevelEditor(ILevelEditor l)
		{
			if (realLevelEditor != null)
			{
				realLevelEditor.SaveManager.OnLevelLoading -= OnLevelLoading;
				realLevelEditor.SaveManager.OnLevelLoaded -= OnLevelLoaded;
				realLevelEditor.ObjectManager.OnCreatedObject -= OnObjectManagerCreatedObject;
				realLevelEditor.ObjectManager.OnDeletedObject -= OnObjectManagerDeleteObject;
				realLevelEditor.Selection.OnSelectionChanged -= OnSelectionChanged;

				realLevelEditor = null;
			}

			if (l != null)
			{
				realLevelEditor = l;
				l.SaveManager.OnLevelLoading += OnLevelLoading;
				l.SaveManager.OnLevelLoaded += OnLevelLoaded;
				l.ObjectManager.OnCreatedObject += OnObjectManagerCreatedObject;
				l.ObjectManager.OnDeletedObject += OnObjectManagerDeleteObject;
				l.Selection.OnSelectionChanged += OnSelectionChanged;
				treeControl.SetItems(l.ObjectManager.GetAllObjects());
			}
		}

		private void OnLevelLoading(object sender, LevelSavingLoadingArgs e)
		{
			loadingLevel = true;
		}

		private void OnLevelLoaded(object sender, LevelEventArgs e)
		{
			treeControl.ClearItems();

			if (realLevelEditor == null)
			{
				return;
			}

			loadingLevel = false;
			List<ILevelEditorObject> allObjects = realLevelEditor.ObjectManager.GetAllObjects();
			for (int i = 0; i < allObjects.Count; i++)
			{
				if (allObjects[i].MyGameObject.transform.parent == null)
				{
					treeControl.AddItem(allObjects[i], false);
				}
			}

			treeControl.UpdateList();
		}

		private void OnObjectManagerCreatedObject(object sender, LevelEditorObjectEvent args)
		{
			args.Object.OnStateChanged += OnObjectStateChanged;
			if (!loadingLevel)
			{
				treeControl.AddItem(args.Object);
			}
		}

		private void OnObjectManagerDeleteObject(object sender, LevelEditorObjectEvent args)
		{
			args.Object.OnStateChanged -= OnObjectStateChanged;
			if (!loadingLevel)
			{
				treeControl.RemoveItem(args.Object);
			}
		}

		private void OnObjectStateChanged(object sender, LevelEditorObjectStateArgs e)
		{
			treeControl.RebindItem(sender);
		}

		private void OnSelectionChanged(object sender, SelectionEventArgs e)
		{
			if (selectedThroughUI)
			{
				selectedThroughUI = false;
				return;
			}

			selectedThroughObjectManager = true;

			treeControl.SelectItem(e.NewObject);
		}

		private void OnBindItem(object sender, TreeBindItemEventArgs<HierarchyItem, ILevelEditorObject> e)
		{
			e.TreeItem.LabelText.text = e.Item.MyGameObject.name;
			e.TreeItem.HasChildren = e.Item.HasChildren();

#if UNITY_EDITOR
			e.TreeItem.gameObject.name = $"Item - {e.Item.MyGameObject.name}";
#endif
		}

		private void OnReparentItem(object sender, TreeReparentEventArgs<ILevelEditorObject> e)
		{
			if (e.DraggingItem.Parent != null)
			{
				e.DraggingItem.Parent.RemoveChild(e.DraggingItem);
			}

			switch (e.Action)
			{
				case ItemDropAction.SetLastChild:
					if (e.Target != null)
					{
						e.DraggingItem.MyGameObject.transform.SetParent(e.Target.MyGameObject.transform, true);
						e.DraggingItem.MyGameObject.transform.SetAsLastSibling();
						e.DraggingItem.Parent = e.Target;
						e.DraggingItem.Parent.AddChild(e.DraggingItem);
					}
					else
					{
						e.DraggingItem.MyGameObject.transform.SetParent(null, true);
						e.DraggingItem.Parent = null;
					}

					break;
				case ItemDropAction.SetPreviousSibling:
					if (e.Target != null)
					{
						if (e.DraggingItem.Parent != e.Target.Parent)
						{
							e.DraggingItem.MyGameObject.transform.SetParent(e.Target.MyGameObject.transform.parent, true);
							e.DraggingItem.Parent = e.Target.Parent;
							if (e.DraggingItem.Parent != null)
							{
								e.DraggingItem.Parent.AddChild(e.DraggingItem);
							}
						}

						int targetIndex = e.Target.MyGameObject.transform.GetSiblingIndex();
						int currentIndex = e.DraggingItem.MyGameObject.transform.GetSiblingIndex();

						if (targetIndex > currentIndex)
						{
							e.DraggingItem.MyGameObject.transform.SetSiblingIndex(targetIndex - 1);
						}
						else
						{
							e.DraggingItem.MyGameObject.transform.SetSiblingIndex(targetIndex);
						}
					}

					break;
				case ItemDropAction.SetNextSibling:
					if (e.Target != null)
					{
						int targetIndex = e.Target.MyGameObject.transform.GetSiblingIndex();
						int currentIndex = e.DraggingItem.MyGameObject.transform.GetSiblingIndex();

						if (e.DraggingItem.Parent != e.Target.Parent)
						{
							e.DraggingItem.MyGameObject.transform.SetParent(e.Target.MyGameObject.transform.parent, true);
							e.DraggingItem.MyGameObject.transform.SetSiblingIndex(targetIndex + 1);
							e.DraggingItem.Parent = e.Target.Parent;
							if (e.DraggingItem.Parent != null)
							{
								e.DraggingItem.Parent.AddChild(e.DraggingItem);
							}
						}
						else
						{
							if (targetIndex < currentIndex)
							{
								e.DraggingItem.MyGameObject.transform.SetSiblingIndex(targetIndex + 1);
							}
							else
							{
								e.DraggingItem.MyGameObject.transform.SetSiblingIndex(targetIndex);
							}
						}
					}

					break;
			}
		}

		private void OnItemExpanding(object sender, TreeExpandingEventArgs<ILevelEditorObject> e)
		{
			if (e.Parent.HasChildren())
			{
				for (int i = 0; i < e.Parent.Children.Count; i++)
				{
					e.Children.Add(e.Parent.Children[i]);
				}
			}
		}

		private void OnTreeSelectionChanged(object sender, TreeSelectionArgs<ILevelEditorObject> e)
		{
			if (!selectedThroughObjectManager)
			{
				selectedThroughUI = true;
				selectedThroughObjectManager = false;
			}

			if (realLevelEditor != null)
			{
				realLevelEditor.Selection.SetSelection(e.New);
			}
		}
	}
}