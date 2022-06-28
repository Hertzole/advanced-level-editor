using System.Collections.Generic;

namespace Hertzole.ALE
{
	public class PathNode
	{
		public string Path { get; }
		public bool IsDirectory { get; }
		public PathNode Parent { get; }
		
		public PathNode[] Children { get; set; }
		
		public bool HasChildren { get { return Children != null && Children.Length > 0; } }

		public PathNode(string path, bool isDirectory, PathNode parent)
		{
			Path = path;
			IsDirectory = isDirectory;
			Parent = parent;
		}

		public override string ToString()
		{
			return $"PathNode ({System.IO.Path.GetDirectoryName(Path)})";
		}
	}
}