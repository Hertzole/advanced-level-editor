using Hertzole.ALE;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE.Generated
{
	public class NewSerializeTestFormatter : IMessagePackFormatter<NewSerializeTestScript.WrapperTemplate>
    {
        public void Serialize(ref MessagePackWriter writer, NewSerializeTestScript.WrapperTemplate value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(8);
            writer.WriteInt32(value.testString.Item1);
            options.Resolver.GetFormatter<string>().Serialize(ref writer, value.testString.Item2, options);
            writer.WriteInt32(value.testInt.Item1);
            writer.WriteInt32(value.testInt.Item2);
            writer.WriteInt32(value.testVector3.Item1);
            options.Resolver.GetFormatter<Vector3>().Serialize(ref writer, value.testVector3.Item2, options);
            writer.WriteInt32(value.reference.Item1);
            options.Resolver.GetFormatter<ComponentDataWrapper>().Serialize(ref writer, value.reference.Item2, options);
        }

        public NewSerializeTestScript.WrapperTemplate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            int length = reader.ReadArrayHeader();
            string testString = null;
            int testInt = 0;
            Vector3 testVector3 = new Vector3();
            ComponentDataWrapper reference = new ComponentDataWrapper();
            for (int i = 0; i < length; i++)
            {
                if(i % 2 == 0)
                {
                    int id = reader.ReadInt32();
                    if (id == 220)
                    {
                        testString = reader.ReadString();
                    }
                    else if (id == 1)
                    {
                        testInt = reader.ReadInt32();
                    }
                    else if (id == 2)
                    {
                        testVector3 = options.Resolver.GetFormatter<Vector3>().Deserialize(ref reader, options);
                    }
                    else if (id == 100)
                    {
                        reference = options.Resolver.GetFormatter<ComponentDataWrapper>().Deserialize(ref reader, options);
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
            }
            
            reader.Depth--;
            return new NewSerializeTestScript.WrapperTemplate(testString, testInt, testVector3, reference);
        }
    }
}