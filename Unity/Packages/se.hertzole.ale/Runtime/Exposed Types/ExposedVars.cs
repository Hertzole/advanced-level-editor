using System.Collections.Generic;

namespace Hertzole.ALE
{
	public class ExposedVars
	{
		private readonly Dictionary<int, ExposedVar> exposedVars = new Dictionary<int, ExposedVar>();

		public ExposedVars(params ExposedVar[] exposedVars)
		{
			foreach (ExposedVar exposedVar in exposedVars)
			{
				this.exposedVars.Add(exposedVar.ID, exposedVar);
			}
		}

		public bool TryGetExposedVar<T>(int id, out ExposedVar<T> exposedVar)
		{
			if (exposedVars.TryGetValue(id, out ExposedVar var))
			{
				exposedVar = (ExposedVar<T>) var;
				return true;
			}

			exposedVar = null;
			return false;
		}
	}
}