using System;
using UnityEngine;

namespace Hertzole.ALE
{
	public interface ILevelEditorModal
	{
		GameObject MyGameObject { get; }

		event Action OnClose;

		void Close();
	}
}