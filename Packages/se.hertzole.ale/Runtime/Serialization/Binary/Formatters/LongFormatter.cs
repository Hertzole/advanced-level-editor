using System.IO;

namespace Hertzole.ALE
{
    public class LongFormatter : BaseFormatter<long>
    {
        public override long Deserialize(BinaryReader reader)
        {
            return reader.ReadInt64();
        }

        public override void Serialize(long value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
