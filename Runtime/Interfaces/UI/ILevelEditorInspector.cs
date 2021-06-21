using System;
using UnityEngine;
#if ALE_LOCALIZATION
using UnityEngine.Localization;
#endif

namespace Hertzole.ALE
{
#if ALE_LOCALIZATION
	[Serializable]
	public struct LocalizedInspectorField
	{
		public string key;
		public LocalizedString value;
	}
#endif

	public interface ILevelEditorInspector
	{
		void Initialize(ILevelEditorUI ui);

		void BindObject(ILevelEditorObject target);

		LevelEditorInspectorField GetField(Type fieldType, Transform parent);

		void PoolField(LevelEditorInspectorField field);

		bool HasField(Type type);

#if ALE_LOCALIZATION
		LocalizedString GetLocalizedInspectorField(string key);
#endif
	}
}