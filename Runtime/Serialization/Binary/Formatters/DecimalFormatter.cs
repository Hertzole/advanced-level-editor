using System.IO;

namespace Hertzole.ALE
{
    public class DecimalFormatter : BaseFormatter<decimal>
    {
        public override decimal Deserialize(BinaryReader reader)
        {
            return reader.ReadDecimal();
        }

        public override void Serialize(decimal value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
