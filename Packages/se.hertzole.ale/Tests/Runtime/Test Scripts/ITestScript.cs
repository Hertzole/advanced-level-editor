namespace Hertzole.ALE.Tests.TestScripts
{
	public interface IValue<T>
	{
		int ValueID { get; }
		
		T Value { get; set; }
	}

	public interface IValues<T>
	{
		int Value1ID { get; }
		int Value2ID { get; }
		
		T Value1 { get; set; }
		T Value2 { get; set; }
	}
}