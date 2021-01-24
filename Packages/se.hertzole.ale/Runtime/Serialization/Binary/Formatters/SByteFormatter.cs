using System.IO;

namespace Hertzole.ALE
{
    public class SByteFormatter : BaseFormatter<sbyte>
    {
        public override sbyte Deserialize(BinaryReader reader)
        {
            return reader.ReadSByte();
        }

        public override void Serialize(sbyte value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
