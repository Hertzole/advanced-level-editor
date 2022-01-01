using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class TestPlayMode : MonoBehaviour, ILevelEditorPlayMode
	{
		public bool IsPlaying { get; private set; }
		public event Action OnStartPlayMode;
		public event Action OnStopPlayMode;

		public bool CanStartPlayMode(out string failReason)
		{
			failReason = string.Empty;
			return true;
		}

		public bool CanStopPlayMode(out string failReason)
		{
			failReason = string.Empty;
			return true;
		}

		public void StartPlayMode(ILevelEditor levelEditor)
		{
			List<ILevelEditorObject> allObjects = levelEditor.ObjectManager.GetAllObjects();
			for (int i = 0; i < allObjects.Count; i++)
			{
				allObjects[i].StartPlayMode();
			}

			IsPlaying = true;
			
			OnStartPlayMode?.Invoke();
		}

		public void StopPlayMode(ILevelEditor levelEditor)
		{
			List<ILevelEditorObject> allObjects = levelEditor.ObjectManager.GetAllObjects();
			for (int i = 0; i < allObjects.Count; i++)
			{
				allObjects[i].StopPlayMode();
			}

			IsPlaying = false;
			
			OnStopPlayMode?.Invoke();
		}
	}
}