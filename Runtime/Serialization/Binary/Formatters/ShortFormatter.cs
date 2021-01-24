using System.IO;

namespace Hertzole.ALE
{
    public class ShortFormatter : BaseFormatter<short>
    {
        public override short Deserialize(BinaryReader reader)
        {
            return reader.ReadInt16();
        }

        public override void Serialize(short value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
