using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public static class InitializeHelper
	{
		private static readonly List<ILevelEditorInitialize> initializes = new List<ILevelEditorInitialize>();

		public static void TryInitializeObject(GameObject obj)
		{
			if (obj == null)
			{
				return;
			}

			initializes.Clear();

			obj.GetComponents(initializes);

			for (int i = 0; i < initializes.Count; i++)
			{
				initializes[i].Initialize();
			}

			initializes.Clear();
		}

		public static void TryInitializeObject(Component obj)
		{
			if (obj == null)
			{
				return;
			}

			initializes.Clear();

			obj.GetComponents(initializes);

			for (int i = 0; i < initializes.Count; i++)
			{
				initializes[i].Initialize();
			}

			initializes.Clear();
		}
	}
}