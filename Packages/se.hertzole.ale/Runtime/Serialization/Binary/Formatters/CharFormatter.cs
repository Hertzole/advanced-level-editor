using System.IO;

namespace Hertzole.ALE
{
    public class CharFormatter : BaseFormatter<char>
    {
        public override char Deserialize(BinaryReader reader)
        {
            return reader.ReadChar();
        }

        public override void Serialize(char value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
