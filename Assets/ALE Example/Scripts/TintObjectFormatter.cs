using Hertzole.ALE;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

public class TintObjectFormatter : IMessagePackFormatter<TintObject.Wrapper>
{
    public void Serialize(ref MessagePackWriter writer, TintObject.Wrapper value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(2);
        writer.WriteInt32(value.Color.Item1);
        options.Resolver.GetFormatter<Color32>().Serialize(ref writer, value.Color.Item2, options);
    }

    public TintObject.Wrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        options.Security.DepthStep(ref reader);

        int length = reader.ReadArrayHeader();
        Color32 Color = new Color32();
        for (int i = 0; i < length; i++)
        {
            if(i % 2 == 0)
            {
                int id = reader.ReadInt32();
                if (id == 0)
                {
                    Color = options.Resolver.GetFormatter<Color32>().Deserialize(ref reader, options);
                }
                else
                {
                    reader.Skip();
                }
            }
        }
        
        reader.Depth--;
        return new TintObject.Wrapper(Color);
    }
}
