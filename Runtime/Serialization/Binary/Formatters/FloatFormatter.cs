using System.IO;

namespace Hertzole.ALE
{
    public class FloatFormatter : BaseFormatter<float>
    {
        public override float Deserialize(BinaryReader reader)
        {
            return reader.ReadSingle();
        }

        public override void Serialize(float value, BinaryWriter writer)
        {
            writer.Write(value);
        }
    }
}
