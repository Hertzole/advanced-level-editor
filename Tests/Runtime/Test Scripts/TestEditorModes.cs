namespace Hertzole.ALE.Tests
{
	public class TestEditorMode : LevelEditorMode
	{
		public bool modeEnabled;
		public bool updating;

		public override void OnModeEnable()
		{
			modeEnabled = true;
		}

		public override void OnModeDisable()
		{
			modeEnabled = false;
			updating = false;
		}

		public override void OnModeUpdate()
		{
			updating = true;
		}
	}

	public class TestEditorMode1 : TestEditorMode { }

	public class TestEditorMode2 : TestEditorMode { }

	public class TestEditorMode3 : TestEditorMode { }
}