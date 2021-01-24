using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class Vector4Formatter : BaseFormatter<Vector4>
    {
        public override Vector4 Deserialize(BinaryReader reader)
        {
            return new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public override void Serialize(Vector4 value, BinaryWriter writer)
        {
            writer.Write(value.x);
            writer.Write(value.y);
            writer.Write(value.z);
            writer.Write(value.w);
        }
    }
}
