using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Hertzole.ALE
{
	public class LevelEditorCustomDataFormatter : IMessagePackFormatter<LevelEditorCustomData>
	{
		public void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);

			writer.WriteInt32(value.type.FullName.GetStableHashCode());
			((LevelEditorResolver) LevelEditorResolver.instance).SerializeDynamic(value.type, ref writer, value.value, options);
		}

		public LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);

			object value = null;
			Type type = null;

#if ALE_COMPATIBILITY_0
			LevelEditorSerializerOptions levelEditorOptions = options as LevelEditorSerializerOptions;
			if (levelEditorOptions != null && levelEditorOptions.SaveVersion == 0)
			{
				DeserializeFormat0(ref reader, options, ref type, ref value);
			}
			else
#endif
			{
				DeserializeFormat1(ref reader, options, ref type, ref value);
			}

			reader.Depth--;

			return new LevelEditorCustomData(type, value);
		}

#if ALE_COMPATIBILITY_0
		private static void DeserializeFormat0(ref MessagePackReader reader, MessagePackSerializerOptions options, ref Type type, ref object value)
		{
			int count = reader.ReadMapHeader();
			for (int i = 0; i < count; i++)
			{
				ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader);
				switch (stringKey.Length)
				{
					default:
						FAIL:
						reader.Skip();
						continue;
					case 4:
						if (AutomataKeyGen.GetKey(ref stringKey) != 1701869940UL)
						{
							goto FAIL;
						}

						type = LevelEditorSerializer.GetType(reader.ReadInt32());
						continue;
					case 5:
						if (AutomataKeyGen.GetKey(ref stringKey) != 435761734006UL)
						{
							goto FAIL;
						}

						((LevelEditorResolver) LevelEditorResolver.instance).DeserializeDynamic(type, ref reader, out value, options);
						continue;
				}
			}
		}
#endif

		private static void DeserializeFormat1(ref MessagePackReader reader, MessagePackSerializerOptions options, ref Type type, ref object value)
		{
			int count = reader.ReadArrayHeader();
			for (int i = 0; i < count; i++)
			{
				switch (i)
				{
					case 0:
						type = LevelEditorSerializer.GetType(reader.ReadInt32());
						break;
					case 1:
						((LevelEditorResolver) LevelEditorResolver.instance).DeserializeDynamic(type, ref reader, out value, options);
						break;
				}
			}
		}
	}
}