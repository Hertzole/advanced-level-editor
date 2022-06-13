using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public abstract class BaseCustomDataTestScript : MonoBehaviour
	{
		public LevelEditorSaveManager saveManager;

		private LevelEventArgs args;

		private void Awake()
		{
			saveManager = FindObjectOfType<LevelEditorSaveManager>();
		}

		private void OnEnable()
		{
			saveManager.OnLevelSaving += OnLevelSaving;
			saveManager.OnLevelLoaded += OnLevelLoaded;
		}

		private void OnDisable()
		{
			saveManager.OnLevelSaving -= OnLevelSaving;
			saveManager.OnLevelLoaded -= OnLevelLoaded;
		}

		private void OnLevelSaving(object sender, LevelSavingLoadingArgs e)
		{
			AddCustomData(e);
		}

		private void OnLevelLoaded(object sender, LevelEventArgs e)
		{
			ValidateCustomData(e);
		}

		protected abstract void AddCustomData(LevelSavingLoadingArgs e);

		protected abstract void ValidateCustomData(LevelEventArgs e);
	}
}