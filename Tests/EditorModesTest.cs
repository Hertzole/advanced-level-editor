using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public class EditorModesTest : LevelEditorTest
	{
		private TestEditorMode1 mode1;
		private TestEditorMode2 mode2;
		private TestEditorMode3 mode3;
		
		protected override void OnSceneSetup(List<GameObject> objects)
		{
			base.OnSceneSetup(objects);

			mode1 = levelEditor.gameObject.AddComponent<TestEditorMode1>();
			mode2 = levelEditor.gameObject.AddComponent<TestEditorMode2>();
			mode3 = levelEditor.gameObject.AddComponent<TestEditorMode3>();

			ILevelEditorMode[] modes = { mode1, mode2, mode3 };

			levelEditor.EditorModes = modes;
		}

		[UnityTest]
		public IEnumerator TestEnabled()
		{
			Assert.IsTrue(mode1.modeEnabled);
			Assert.IsFalse(mode2.modeEnabled);
			Assert.IsFalse(mode3.modeEnabled);

			levelEditor.SetMode<TestEditorMode2>();

			yield return null;

			Assert.IsFalse(mode1.modeEnabled);
			Assert.IsTrue(mode2.modeEnabled);
			Assert.IsFalse(mode3.modeEnabled);

			levelEditor.SetMode<TestEditorMode3>();

			yield return null;

			Assert.IsFalse(mode1.modeEnabled);
			Assert.IsFalse(mode2.modeEnabled);
			Assert.IsTrue(mode3.modeEnabled);
		}

		[UnityTest]
		public IEnumerator TestUpdating()
		{
			Assert.IsTrue(mode1.updating);
			Assert.IsFalse(mode2.updating);
			Assert.IsFalse(mode3.updating);

			levelEditor.SetMode<TestEditorMode2>();

			yield return null;

			Assert.IsFalse(mode1.updating);
			Assert.IsTrue(mode2.updating);
			Assert.IsFalse(mode3.updating);

			levelEditor.SetMode<TestEditorMode3>();

			yield return null;

			Assert.IsFalse(mode1.updating);
			Assert.IsFalse(mode2.updating);
			Assert.IsTrue(mode3.updating);
		}

		/// <summary>
		/// Used because there are some extra conditions when play mode is present.
		/// </summary>
		/// <returns></returns>
		[UnityTest]
		public IEnumerator TestUpdatingWithPlaymode()
		{
			TestPlayMode playMode = levelEditor.gameObject.AddComponent<TestPlayMode>();
			levelEditor.PlayMode = playMode;
		
			yield return null;
	
			Assert.IsTrue(mode1.updating);
			Assert.IsFalse(mode2.updating);
			Assert.IsFalse(mode3.updating);

			levelEditor.SetMode<TestEditorMode2>();

			yield return null;

			Assert.IsFalse(mode1.updating);
			Assert.IsTrue(mode2.updating);
			Assert.IsFalse(mode3.updating);

			levelEditor.SetMode<TestEditorMode3>();

			yield return null;

			Assert.IsFalse(mode1.updating);
			Assert.IsFalse(mode2.updating);
			Assert.IsTrue(mode3.updating);
		}
	}
}