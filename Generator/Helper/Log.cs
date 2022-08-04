using System;
using System.Collections.Generic;
using System.IO;

namespace Hertzole.ALE.Generator.Helper;

internal static class Log
{
	public static List<string> Logs { get; } = new List<string>();

	public static void Print(string msg)
	{
		Logs.Add(msg);
	}

	// More print methods ...

	public static void FlushLogs()
	{
		File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/logs.log", string.Join("\n", Logs));
	}
}