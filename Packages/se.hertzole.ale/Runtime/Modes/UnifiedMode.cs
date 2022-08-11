using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
	[DisallowMultipleComponent]
	[AddComponentMenu("ALE/Editor Modes/Unified Mode", 500)]
#endif
	public class UnifiedMode : LevelEditorMode
	{
		[SerializeField]
		[RequireType(typeof(ILevelEditorResourceView))]
		private GameObject resourcePanel = null;
		[SerializeField]
		private ManipulationHandle handle = default;

		[Header("Input")]
		[SerializeField]
		private string selectAction = "Select";
		[SerializeField]
		private string moveTypeInput = "Handle Set Move";
		[SerializeField]
		private string rotateTypeInput = "Handle Set Rotate";
		[SerializeField]
		private string scaleTypeInput = "Handle Set Scale";
		[SerializeField]
		private string allType = "Handle Set All";
		[SerializeField] 
		private string deleteInput = "Delete";

		private ILevelEditorResourceView realResourcePanel;

		private void Awake()
		{
			realResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();

			if (handle != null)
			{
				handle.Initialize(Input, Undo);
			}
		}

		public override void OnModeEnable()
		{
			realResourcePanel.OnClickAsset += OnClickAsset;
			Selection.OnSelectionChanged += OnSelectionChanged;
		}

		public override void OnModeDisable()
		{
			realResourcePanel.OnClickAsset -= OnClickAsset;
			Selection.OnSelectionChanged -= OnSelectionChanged;
		}

		public override void OnModeUpdate()
		{
			if (handle != null && !LevelEditor.LevelEditorCamera.IsUsingMouse() && !LevelEditor.UI.IsInputFieldSelected())
			{
				if (Input.GetButtonDown(moveTypeInput))
				{
					handle.TransformType = ManipulationHandle.TransformTypes.Move;
				}
				else if (Input.GetButtonDown(rotateTypeInput))
				{
					handle.TransformType = ManipulationHandle.TransformTypes.Rotate;
				}
				else if (Input.GetButtonDown(scaleTypeInput))
				{
					handle.TransformType = ManipulationHandle.TransformTypes.Scale;
				}
				else if (Input.GetButtonDown(allType))
				{
					handle.TransformType = ManipulationHandle.TransformTypes.All;
				}
			}

			if (Input.GetButtonDown(deleteInput) && Selection.Selection != null)
			{
				ObjectManager.DeleteObject(Selection.Selection, true);
			}
		}

		public override void OnModeLateUpdate()
		{
			if (Input.GetButtonDown(selectAction) && CanSelectObject())
			{
				GameObject go = LevelEditorWorld.Raycast(LevelEditor.LevelEditorCamera.CameraComponent.ScreenPointToRay(Input.MousePosition));
				Selection.SetSelection(go != null ? go.GetComponent<ILevelEditorObject>() : null);
			}
		}

		private void OnClickAsset(object sender, AssetClickEventArgs e)
		{
			if (e.Resource.Asset is GameObject)
			{
				ILevelEditorObject obj = ObjectManager.CreateObject(e.Resource);
				Selection.SetSelection(obj);
			}
		}

		private void OnSelectionChanged(object sender, SelectionEventArgs e)
		{
			if (handle != null)
			{
				if (e.NewObject != null)
				{
					handle.ClearTargets();
					handle.AddTarget(e.NewObject.MyGameObject.transform);
				}
				else
				{
					handle.ClearTargets();
				}
			}
		}

		private bool CanSelectObject()
		{
			if (handle != null)
			{
				return !handle.IsTransforming && !Input.IsMouseOverUI();
			}

			return !Input.IsMouseOverUI();
		}
	}
}