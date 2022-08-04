namespace Hertzole.ALE.Generator.Data;

public struct Result<T>
{
	public T Value { get; }

	public bool Success { get; }
	
	public Result(T value)
	{
		Value = value;
		Success = true;
	}
}