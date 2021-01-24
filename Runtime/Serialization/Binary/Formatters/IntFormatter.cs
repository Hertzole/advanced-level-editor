using System.IO;

namespace Hertzole.ALE
{
    public class IntFormatter : BaseFormatter<int>
    {
        public override int Deserialize(BinaryReader reader)
        {
            return reader.ReadInt32();
        }

        public override void Serialize(int value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
