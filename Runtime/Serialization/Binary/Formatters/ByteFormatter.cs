using System.IO;

namespace Hertzole.ALE
{
    public class ByteFormatter : BaseFormatter<byte>
    {
        public override byte Deserialize(BinaryReader reader)
        {
            return reader.ReadByte();
        }

        public override void Serialize(byte value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
