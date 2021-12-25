---
sidebar_position: 4
---

# Custom Types

When your type isn't a C# primitive or a Unity primitive, ALE will attempt to create a serializer for it. 

At the moment, only `struct` types can be serialized. For all the rules that apply when serializing a custom type, see
[Serialization Rules/When serializing custom types](/docs/serialization/about-serialization/#when-serializing-custom-types).

<details><summary>Generated Code</summary>
<p>

This is the struct that it will serialize.

```cs
public struct MyStruct
{
	public int test1;
	public string test2;
}
```

This is the generated formatter.

```cs
using System;
using Hertzole.ALE.Tests.TestScripts;
using MessagePack;
using MessagePack.Formatters;

public class MyStruct_Formatter : IMessagePackFormatter<MyStruct>, IMessagePackFormatter
{
	public void Serialize(ref MessagePackWriter writer, MyStruct value, MessagePackSerializerOptions options)
	{
		IFormatterResolver resolver = options.Resolver;
		writer.WriteArrayHeader(4);
		// Hashed from value1
		writer.WriteInt32(768721960);
		writer.WriteInt32(value.test1);
		// Hashed from value2
		writer.WriteInt32(768721961);
		resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.test2, options);
	}

	public MyStruct Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		if (reader.TryReadNil())
		{
			throw new InvalidOperationException("typecode is null, struct not supported");
		}
		options.Security.DepthStep(ref reader);
		int test = 0;
		string test2 = null;
		DeserializeFormat1(ref reader, options, ref test, ref test2);
		MyStruct result = default(MyStruct);
		result.test1 = test;
		result.test2 = test2;
		reader.Depth--;
		return result;
	}

	private static void DeserializeFormat1(ref MessagePackReader P_0, MessagePackSerializerOptions P_1, ref int test1, ref string test2)
	{
		IFormatterResolver resolver = P_1.Resolver;
		int num = P_0.ReadArrayHeader();
		for (int i = 0; i < num / 2; i++)
		{
			switch (P_0.ReadInt32())
			{
			case 768721960: // value1
				test1 = P_0.ReadInt32();
				break;
			case 768721961: // value2
				test2 = P_0.ReadString();
				break;
			default:
				P_0.Skip();
				break;
			}
		}
	}
}
```

</p>

</details>