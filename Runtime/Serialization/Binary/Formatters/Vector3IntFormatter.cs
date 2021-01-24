using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class Vector3IntFormatter : BaseFormatter<Vector3Int>
    {
        public override Vector3Int Deserialize(BinaryReader reader)
        {
            return new Vector3Int(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        }

        public override void Serialize(Vector3Int value, BinaryWriter writer)
        {
            writer.Write(value.x);
            writer.Write(value.y);
            writer.Write(value.z);
        }
    }
}
