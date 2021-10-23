using System;
using Hertzole.ALE;
using Hertzole.ALE.Example;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using UnityEngine;

public class StructFormatterTemplate : IMessagePackFormatter<SaveData>
{
	public void Serialize(ref MessagePackWriter writer, SaveData value, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(2);
		writer.WriteInt32(123456);
		writer.Write(value.message);
		writer.WriteInt32(456778);
		writer.WriteInt32(value.number);
	}

	public SaveData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		if (reader.TryReadNil())
		{
			throw new InvalidOperationException("typecode is null, struct not supported");
		}

		options.Security.DepthStep(ref reader);
		string message = null;
		int number = 0;

#if ALE_COMPATIBILITY_0
		if (options is LevelEditorSerializerOptions levelEditorOptions && levelEditorOptions.SaveVersion == 0)
		{
			DeserializeFormat0(ref reader, options, ref message, ref number);
		}
		else
#endif
		{
			DeserializeFormat1(ref reader, options, ref message, ref number);
		}

		SaveData result = default;
		result.message = message;
		result.number = number;
		reader.Depth--;
		return result;
	}

	private static void DeserializeFormat0(ref MessagePackReader reader, MessagePackSerializerOptions options, ref string message, ref int number)
	{
		int length = reader.ReadMapHeader();
		int i = 0;
		IFormatterResolver resolver = options.Resolver;
		while (i < length)
		{
			ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader);
			int length2 = stringKey.Length;
			ulong key = 0uL;
			if (length2 <= 8)
			{
				key = AutomataKeyGen.GetKey(ref stringKey);
			}

			if (length2 == 7 && key == 28542640894207341L)
			{
				message = reader.ReadString();
			}
			else if (length2 == 6 && key == 125779768604014L)
			{
				number = reader.ReadInt32();
			}
			else
			{
				reader.Skip();
			}

			i++;
		}
	}

	private static void DeserializeFormat1(ref MessagePackReader reader, MessagePackSerializerOptions options, ref string message, ref int number)
	{
		int length = reader.ReadArrayHeader();
		for (int i = 0; i < length; i++)
		{
			int hash = reader.ReadInt32();

			if (hash == 420 || hash == 69 || hash == 7)
			{
				message = reader.ReadString();
				continue;
			}

			if (hash == 456778)
			{
				number = reader.ReadInt32();
				continue;
			}
				
			reader.Skip();
		}
	}
}