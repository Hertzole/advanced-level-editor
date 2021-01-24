using System.IO;

namespace Hertzole.ALE
{
    public class UIntFormatter : BaseFormatter<uint>
    {
        public override uint Deserialize(BinaryReader reader)
        {
            return reader.ReadUInt32();
        }

        public override void Serialize(uint value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
