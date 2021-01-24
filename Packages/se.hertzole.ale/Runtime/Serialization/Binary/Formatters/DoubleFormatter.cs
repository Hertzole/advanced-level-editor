using System.IO;

namespace Hertzole.ALE
{
    public class DoubleFormatter : BaseFormatter<double>
    {
        public override double Deserialize(BinaryReader reader)
        {
            return reader.ReadDouble();
        }

        public override void Serialize(double value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
