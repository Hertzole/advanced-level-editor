using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class Vector3Formatter : BaseFormatter<Vector3>
    {
        public override Vector3 Deserialize(BinaryReader reader)
        {
            return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public override void Serialize(Vector3 value, BinaryWriter writer)
        {
            writer.Write(value.x);
            writer.Write(value.y);
            writer.Write(value.z);
        }
    }
}
