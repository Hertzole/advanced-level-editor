using System.IO;

namespace Hertzole.ALE
{
    public class UShortFormatter : BaseFormatter<ushort>
    {
        public override ushort Deserialize(BinaryReader reader)
        {
            return reader.ReadUInt16();
        }

        public override void Serialize(ushort value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
