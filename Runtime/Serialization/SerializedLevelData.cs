using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public class SerializedLevelData : IEquatable<SerializedLevelData>
    {
        [JsonProperty("objectPalette")]
        public Dictionary<string, int> ObjectPalette { get; set; }
        [JsonProperty("typePalette")]
        public Dictionary<string, int> TypePalette { get; set; }

        [JsonProperty("data")]
        public LevelEditorSaveData Data { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && obj is SerializedLevelData data && Equals(data);
        }

        public bool Equals(SerializedLevelData other)
        {
            return other != null &&
                   ((ObjectPalette == null && other.ObjectPalette == null) || (ObjectPalette != null && ObjectPalette.DictionaryEquals(other.ObjectPalette))) &&
                   ((TypePalette == null && other.TypePalette == null) || (TypePalette != null && TypePalette.DictionaryEquals(other.TypePalette))) &&
                   Data.Equals(other.Data);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 23;
                hashCode = hashCode * 17 * ObjectPalette.GetHashCode();
                hashCode = hashCode * 17 * TypePalette.GetHashCode();
                hashCode = hashCode * 17 * Data.GetHashCode();

                return hashCode;
            }
        }

        public static bool operator ==(SerializedLevelData left, SerializedLevelData right)
        {
            return EqualityComparer<SerializedLevelData>.Default.Equals(left, right);
        }

        public static bool operator !=(SerializedLevelData left, SerializedLevelData right)
        {
            return !(left == right);
        }
    }
}
