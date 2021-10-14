using System;
using UnityEngine;

namespace Hertzole.ALE
{
	[Serializable]
	public struct LevelEditorIdentifier : IEquatable<LevelEditorIdentifier>
	{
#pragma warning disable CS0414 // Is assigned but never used
		[SerializeField]
		internal string stringValue;
#pragma warning restore CS0414

		[SerializeField]
		internal int value;

		public LevelEditorIdentifier(string id)
		{
			stringValue = null;
			value = id.GetStableHashCode();
		}

		public LevelEditorIdentifier(int hash)
		{
			stringValue = null;
			value = hash;
		}

		public override int GetHashCode()
		{
			return value;
		}

		public static bool operator ==(LevelEditorIdentifier left, LevelEditorIdentifier right)
		{
			return left.value == right.value;
		}

		public static bool operator !=(LevelEditorIdentifier left, LevelEditorIdentifier right)
		{
			return left.value != right.value;
		}

		public static bool operator ==(int left, LevelEditorIdentifier right)
		{
			return left == right.value;
		}

		public static bool operator !=(int left, LevelEditorIdentifier right)
		{
			return left != right.value;
		}

		public static bool operator ==(LevelEditorIdentifier left, int right)
		{
			return left.value == right;
		}

		public static bool operator !=(LevelEditorIdentifier left, int right)
		{
			return left.value != right;
		}

		public static bool operator ==(string left, LevelEditorIdentifier right)
		{
			return left.GetStableHashCode() == right.value;
		}

		public static bool operator !=(string left, LevelEditorIdentifier right)
		{
			return left.GetStableHashCode() != right.value;
		}

		public static bool operator ==(LevelEditorIdentifier left, string right)
		{
			return left.value == right.GetStableHashCode();
		}

		public static bool operator !=(LevelEditorIdentifier left, string right)
		{
			return left.value != right.GetStableHashCode();
		}

		public static implicit operator int(LevelEditorIdentifier identifier)
		{
			return identifier.value;
		}

		public static implicit operator LevelEditorIdentifier(string id)
		{
			return new LevelEditorIdentifier(id);
		}

		public static implicit operator LevelEditorIdentifier(int hash)
		{
			return new LevelEditorIdentifier(hash);
		}

		public override bool Equals(object obj)
		{
			return obj is LevelEditorIdentifier other && Equals(other);
		}

		public bool Equals(LevelEditorIdentifier other)
		{
			return value == other.value;
		}

		public override string ToString()
		{
			return $"LevelEditorIdentifier (hash: {value})";
		}
	}
}