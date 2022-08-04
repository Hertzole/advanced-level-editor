using System;

namespace Hertzole.ALE
{
	public abstract class ExposedVar
	{
		public int ID { get; }

		protected ExposedVar(int id)
		{
			ID = id;
		}
	}

	public class ExposedVar<T> : ExposedVar
	{
		private readonly Func<T> getValue;
		private readonly Action<T> setValue;

		public T Value { get { return GetValue(); } set { SetValue(value); } }

		public ExposedVar(int id, Func<T> getValue, Action<T> setValue) : base(id)
		{
			this.getValue = getValue;
			this.setValue = setValue;
		}

		protected virtual T GetValue()
		{
			return getValue.Invoke();
		}

		protected virtual void SetValue(T value)
		{
			setValue.Invoke(value);
		}
	}
}