namespace Hertzole.ALE
{
	public interface IExposedType
	{
		ExposedVars ExposedVars { get; }

		void InitializeExposedVars();
	}
}