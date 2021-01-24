using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class ColorFormatter : BaseFormatter<Color>
    {
        public override Color Deserialize(BinaryReader reader)
        {
            return new Color32(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
        }

        public override void Serialize(Color value, BinaryWriter writer)
        {
            // Use Color32 because it uses less memory and space.
            Color32 c = value;
            writer.Write(c.r);
            writer.Write(c.g);
            writer.Write(c.b);
            writer.Write(c.a);
        }
    }

    public class Color32Formatter : BaseFormatter<Color32>
    {
        public override Color32 Deserialize(BinaryReader reader)
        {
            return new Color32(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
        }

        public override void Serialize(Color32 value, BinaryWriter writer)
        {
            writer.Write(value.r);
            writer.Write(value.g);
            writer.Write(value.b);
            writer.Write(value.a);
        }
    }
}
