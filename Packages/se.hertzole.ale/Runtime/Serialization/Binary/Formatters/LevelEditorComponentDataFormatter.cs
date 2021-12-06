using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using UnityEngine;

namespace Hertzole.ALE
{
	public class LevelEditorComponentDataFormatter : IMessagePackFormatter<LevelEditorComponentData>
	{
#if ALE_COMPATIBILITY_0
		private static ReadOnlySpan<byte> SpanProperties { get { return new byte[1 + 10] { 170, 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 }; } }
#endif

		public void Serialize(ref MessagePackWriter writer, LevelEditorComponentData value, MessagePackSerializerOptions options)
		{
			if (value.type == null)
			{
				writer.WriteNil();
				return;
			}
			
			writer.WriteArrayHeader(2);

			writer.WriteInt32(value.type.FullName.GetStableHashCode());
			((LevelEditorResolver) LevelEditorResolver.instance).SerializeWrapper(ref writer, value.wrapper, options);
		}

		public LevelEditorComponentData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return new LevelEditorComponentData();
			}
			
			options.Security.DepthStep(ref reader);

			Type type = null;
			IExposedWrapper wrapper = null;

#if ALE_COMPATIBILITY_0
			LevelEditorSerializerOptions levelEditorOptions = options as LevelEditorSerializerOptions;
			if (levelEditorOptions != null && levelEditorOptions.SaveVersion == 0)
			{
				DeserializeFormat0(ref reader, options, ref type, ref wrapper);
			}
			else
#endif
			{
				DeserializeFormat1(ref reader, options, ref type, ref wrapper);
			}

			reader.Depth--;

			return new LevelEditorComponentData(type, wrapper);
		}

#if ALE_COMPATIBILITY_0
		private static void DeserializeFormat0(ref MessagePackReader reader, MessagePackSerializerOptions options, ref Type type, ref IExposedWrapper wrapper)
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
					case 10:
						if (!stringKey.SequenceEqual(SpanProperties.Slice(1)))
						{
							goto FAIL;
						}

						if (type == null)
						{
							Debug.LogWarning($"Couldn't find a wrapper for type hash {typeHash}.");
							reader.Skip();
							continue;
						}

						((LevelEditorResolver) LevelEditorResolver.instance).DeserializeWrapper(type, ref reader, options, out wrapper);
						continue;
				}
			}
		}
#endif

		private static void DeserializeFormat1(ref MessagePackReader reader, MessagePackSerializerOptions options, ref Type type, ref IExposedWrapper wrapper)
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
							reader.Skip();
							continue;
						}
						
						((LevelEditorResolver) LevelEditorResolver.instance).DeserializeWrapper(type, ref reader, options, out wrapper);
						break;
				}
			}
		}
	}
}