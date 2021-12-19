namespace Hertzole.ALE
{
	public static class MathfExtensions
	{
		public static float Squared(this float value)
		{
			return value * value;
		}

		public static float SafeDivide(float value, float divider)
		{
			if (divider == 0)
			{
				return 0;
			}

			return value / divider;
		}
	}
}