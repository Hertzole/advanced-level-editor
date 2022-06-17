using System;
using System.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
	public static class CodeGenLogger
	{
		[Conditional("ALE_DEBUG")]
		public static void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}