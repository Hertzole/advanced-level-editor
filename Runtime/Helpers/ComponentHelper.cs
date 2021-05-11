using UnityEngine;

namespace Hertzole.ALE
{
	public static class ComponentHelper
	{
		public static ComponentDataWrapper GetComponentWrapper(Component obj)
		{
			return new ComponentDataWrapper(obj.GetComponent<ILevelEditorObject>().InstanceID);
		}

		public static ComponentDataWrapper GetComponentWrapper(GameObject go)
		{
			return new ComponentDataWrapper(go.GetComponent<ILevelEditorObject>().InstanceID);
		}
	}
}