using System;
using System.Text;

namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		private static readonly object lockObj = new object();
		private static readonly StringBuilder sb = new StringBuilder();
		
		public static string GetFullName(this Type type)
		{
			lock (lockObj)
			{
				sb.Clear();
				sb.Append(type.Namespace + ".");
				sb.Append(type.Name);

				if (type.IsGenericType && type.GenericTypeArguments.Length > 0)
				{
					sb.Append("<");

					for (int i = 0; i < type.GenericTypeArguments.Length; i++)
					{
						if (!string.IsNullOrEmpty(type.GenericTypeArguments[i].Namespace))
						{
							sb.Append(type.GenericTypeArguments[i].Namespace + ".");
						}
						
						sb.Append(type.GenericTypeArguments[i].Name);
						if (i != type.GenericTypeArguments.Length - 1)
						{
							sb.Append(", ");
						}
					}

					sb.Append(">");
				}

				return sb.ToString();
			}
		}
	}
}