using System;
using System.Collections.Generic;
using System.Linq;

namespace Hertzole.ALE
{
    public struct LevelEditorSaveData : IEquatable<LevelEditorSaveData>
    {
        public string name;
        public List<LevelEditorObjectData> objects;
        internal Dictionary<string, LevelEditorCustomData> customData;

        public const ushort SAVE_VERSION = 1;

        public LevelEditorSaveData(string name)
        {
            this.name = name;

            objects = new List<LevelEditorObjectData>();
            customData = new Dictionary<string, LevelEditorCustomData>();
        }

        public override string ToString()
        {
            return $"ALE Save Data ({name}, {objects.Count} objects, {(customData == null ? "null" : customData.Count.ToString())} custom data)";
        }

        public override bool Equals(object obj)
        {
            return obj is LevelEditorSaveData data && Equals(data);
        }

        public bool Equals(LevelEditorSaveData other)
        {
            return other != null && name == other.name &&
                   ((other.objects == null && objects == null) || (objects != null && objects.SequenceEqual(other.objects))) &&
                   ((other.customData == null && customData == null) || (customData != null && customData.DictionaryEquals(other.customData)));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 23;
                hashCode = hashCode * 17 * name.GetHashCode();
                hashCode = hashCode * 17 * objects.GetHashCode();
                hashCode = hashCode * 17 * customData.GetHashCode();

                return hashCode;
            }
        }

        public static bool operator ==(LevelEditorSaveData left, LevelEditorSaveData right)
        {
            return EqualityComparer<LevelEditorSaveData>.Default.Equals(left, right);
        }

        public static bool operator !=(LevelEditorSaveData left, LevelEditorSaveData right)
        {
            return !(left == right);
        }
    }
}
