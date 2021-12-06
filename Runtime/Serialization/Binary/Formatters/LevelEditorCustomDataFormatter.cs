using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using UnityEngine;

namespace Hertzole.ALE
{
	public class LevelEditorCustomDataFormatter : IMessagePackFormatter<LevelEditorCustomData>
	{
		public void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
		{
			if (value.type == null)
			{
				Debug.LogWarning($"CustomData with value {value.value} type is null, writing nil. ");
				writer.WriteNil();
				return;
			}

			writer.WriteArrayHeader(2);

			writer.WriteInt32(value.type.FullName.GetStableHashCode());
			((LevelEditorResolver) LevelEditorResolver.instance).SerializeDynamic(value.type, ref writer, value.value, options);
		}

		public LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return new LevelEditorCustomData();
			}
			
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
			int typeHash = 0;
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

						typeHash = reader.ReadInt32();
						type = LevelEditorSerializer.GetType(typeHash);
						continue;
					case 5:
						if (AutomataKeyGen.GetKey(ref stringKey) != 435761734006UL)
						{
							goto FAIL;
						}

						if (type == null)
						{
							Debug.LogWarning($"Can't deserialize some custom data because there's no type with hash {typeHash}.");
							reader.Skip();
							break;
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
						if (type == null)
						{
							Debug.LogWarning("Can't deserialize some custom data because no type for it was found.");
							reader.Skip();
							break;
						}
						
						((LevelEditorResolver) LevelEditorResolver.instance).DeserializeDynamic(type, ref reader, out value, options);
						break;
				}
			}
		}
	}
}