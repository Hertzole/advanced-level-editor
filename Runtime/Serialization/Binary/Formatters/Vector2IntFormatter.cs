using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class Vector2IntFormatter : BaseFormatter<Vector2Int>
    {
        public override Vector2Int Deserialize(BinaryReader reader)
        {
            return new Vector2Int(reader.ReadInt32(), reader.ReadInt32());
        }

        public override void Serialize(Vector2Int value, BinaryWriter writer)
        {
            writer.Write(value.x);
            writer.Write(value.y);
        }
    }
}
