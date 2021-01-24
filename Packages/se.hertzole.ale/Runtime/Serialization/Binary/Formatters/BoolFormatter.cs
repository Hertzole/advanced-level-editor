using System.IO;

namespace Hertzole.ALE
{
    public class BoolFormatter : BaseFormatter<bool>
    {
        public override bool Deserialize(BinaryReader reader)
        {
            return reader.ReadBoolean();
        }

        public override void Serialize(bool value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
