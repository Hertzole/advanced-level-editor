using UnityEngine;

namespace Hertzole.ALE.Example
{
	public struct SaveData
	{
		public string message;
		public int number;

		public SaveData(string message, int number)
		{
			this.message = message;
			this.number = number;
		}

		public override string ToString()
		{
			return string.Format(message, number);
		}
	}

	public class CustomDataExample : MonoBehaviour
	{
		[SerializeField] 
		[RequireType(typeof(ILevelEditorSaveManager))]
		private GameObject saveManager = default;

		private ILevelEditorSaveManager save;

		private void Awake()
		{
			save = saveManager.GetComponent<ILevelEditorSaveManager>();
		}

		private void OnEnable()
		{
			if (save != null)
			{
				save.OnLevelSaving += OnLevelSaving;
				save.OnLevelLoaded += OnLevelLoaded;
			}
		}

		private void OnDisable()
		{
			if (save != null)
			{
				save.OnLevelSaving -= OnLevelSaving;
				save.OnLevelLoaded -= OnLevelLoaded;
			}
		}

		private static void OnLevelSaving(object sender, LevelSavingLoadingArgs e)
		{
			e.AddCustomData("time", new SaveData("Hello! This level was saved with the number {0}!", Random.Range(-1000000, 1000000)));
		}

		private static void OnLevelLoaded(object sender, LevelEventArgs e)
		{
			if (e.TryGetCustomData("time", out SaveData data))
			{
				Debug.Log(data);
			}
		}
	}
}