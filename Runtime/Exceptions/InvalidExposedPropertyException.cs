using System;

namespace Hertzole.ALE
{
	public class InvalidExposedPropertyException : Exception
	{
		public InvalidExposedPropertyException(int id) : base($"Could not find a exposed property with the ID {id}") { }
	}
}