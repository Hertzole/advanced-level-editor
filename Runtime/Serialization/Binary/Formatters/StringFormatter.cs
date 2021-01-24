using System.IO;

namespace Hertzole.ALE
{
    public class StringFormatter : BaseFormatter<string>
    {
        public override string Deserialize(BinaryReader reader)
        {
            return reader.ReadString();
        }

        public override void Serialize(string value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
