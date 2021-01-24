using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class Vector2Formatter : BaseFormatter<Vector2>
    {
        public override Vector2 Deserialize(BinaryReader reader)
        {
            return new Vector2(reader.ReadSingle(), reader.ReadSingle());
        }

        public override void Serialize(Vector2 value, BinaryWriter writer)
        {
            writer.Write(value.x);
            writer.Write(value.y);
        }
    }
}
