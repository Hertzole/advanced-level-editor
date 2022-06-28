using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
	public class LevelEditorLoadModal : MonoBehaviour, ILevelEditorLoadModal
	{
		[SerializeField]
		private Button closeButton;
		[SerializeField]
		private PathTree tree;
		[SerializeField]
		private Button loadButton;

		[Space]
		[SerializeField]
		[RequireType(typeof(ILevelEditorSaveManager))]
		private GameObject saveManager;

		private string selectedLevel;

		private PathNode[] rootNodes;

		public ILevelEditorSaveManager SaveManager { get; set; }

		GameObject ILevelEditorModal.MyGameObject { get { return gameObject; } }

		public event Action<string> OnLoadLevel;
		public event Action OnClose;

		private void Awake()
		{
			tree.Initialize(x => x?.Parent, s =>
			{
				List<PathNode> result = new List<PathNode>();

				if (s != null && s.HasChildren)
				{
					result.AddRange(s.Children);
				}

				return result;
			});
			tree.OnBindItem += OnBindTreeItem;
			tree.OnItemExpandingCollapsing += OnTreeExpandingCollapsing;
			tree.OnSelectionChanged += OnTreeSelectionChanged;

			loadButton.onClick.AddListener(ClickLoadLevel);
			closeButton.onClick.AddListener(Close);

			if (saveManager != null)
			{
				SaveManager = saveManager.NeedComponent<ILevelEditorSaveManager>();
			}

			ValidateLoadButton();
		}

		private void OnEnable()
		{
			if (SaveManager != null)
			{
				PopulateLevels(SaveManager.LevelsPath);
			}
		}

		private static void OnBindTreeItem(object sender, TreeBindItemEventArgs<PathTreeItem, PathNode> e)
		{
			e.TreeItem.LabelText.text = Path.GetFileNameWithoutExtension(e.Item.Path);
			e.TreeItem.HasChildren = e.Item.HasChildren;
			e.TreeItem.Icon.gameObject.SetActive(e.Item.IsDirectory);
			
#if UNITY_EDITOR
			e.TreeItem.gameObject.name = $"Path Tree Item - {Path.GetFileNameWithoutExtension(e.Item.Path)}";
#endif
		}
		
		private static void OnTreeExpandingCollapsing(object sender, TreeExpandingEventArgs<PathNode> e)
		{
			if (e.Parent.HasChildren)
			{
				e.Children.AddRange(e.Parent.Children);
			}
		}
		
		private void OnTreeSelectionChanged(object sender, TreeSelectionArgs<PathNode> e)
		{
			// Set it to null if it's a directory. We don't want to load a folder!
			selectedLevel = e.New != null && !e.New.IsDirectory ? e.New.Path : null;
			ValidateLoadButton();
		}

		private void ClickLoadLevel()
		{
			if (SaveManager != null)
			{
				SaveManager.LoadLevel(selectedLevel);
			}
			
			OnLoadLevel?.Invoke(selectedLevel);
			OnClose?.Invoke();
		}

		private void ValidateLoadButton()
		{
			loadButton.interactable = !string.IsNullOrEmpty(selectedLevel);
		}

		public void Close()
		{
			OnClose?.Invoke();
		}

		public void PopulateLevels(string rootPath)
		{
			selectedLevel = null;
			
			Debug.Log($"Find levels at {rootPath} with {SaveManager.FileExtension}");

			rootNodes = BuildPath(null, rootPath, SaveManager.FileExtension);

			tree.SetItems(rootNodes);
		}

		private static PathNode[] BuildPath(PathNode parent, string path, string fileExtension)
		{
			string[] directories = Directory.GetDirectories(path);
			string[] levels = Directory.GetFiles(path, $"*{fileExtension}");
			
			PathNode[] children = new PathNode[directories.Length + levels.Length];
			for (int i = 0; i < directories.Length; i++)
			{
				children[i] = new PathNode(directories[i], true, parent);
				children[i].Children = BuildPath(children[i], directories[i], fileExtension);
			}
			
			for (int i = directories.Length; i < levels.Length + directories.Length; i++)
			{
				children[i] = new PathNode(levels[i - directories.Length], false, parent);
			}

			return children;
		}
	}
}