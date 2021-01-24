using System.IO;

namespace Hertzole.ALE
{
    public class ULongFormatter : BaseFormatter<ulong>
    {
        public override ulong Deserialize(BinaryReader reader)
        {
            return reader.ReadUInt64();
        }

        public override void Serialize(ulong value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
